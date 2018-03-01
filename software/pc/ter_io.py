import logging
from ter_utils import convertBool
from PyQt5.QtCore import QThread
from time import sleep, time
from queue import Queue
import uuid

# dummy class, will be replaced by the gpiozero module
class DigitalOutputDevice():
    def __init__(self, pin, active_high=True, initial_value=False):
        self.pin = pin
        self.value = initial_value
        
    def toggle(self):
        self.value = not self.value

    def on(self):
        self.value = True

    def off(self):
        self.value = False


class TerIO():
    def __init__(self):
        self.lamps = {
            'red': DigitalOutputDevice(1, active_high=True, initial_value=False),
            'white': DigitalOutputDevice(2, active_high=True, initial_value=False),
            'blueL': DigitalOutputDevice(3, active_high=True, initial_value=False),
            'blueR': DigitalOutputDevice(4, active_high=True, initial_value=False)
        }
        self.heater = DigitalOutputDevice(5, active_high=True, initial_value=False)
        self.log = logging.getLogger('IO')
        self.log.info('IO init')


iosQ = Queue()

class IOEvents():
    def __init__(self, toggle, on, off):
        self.actions = {
            'toggle': toggle,
            'on': on,
            'off': off
        }
    def __getitem__(self, item):
        return self.actions[item]

class IOManager(QThread):
    BUTTON_SUPPRESS_TIME = 2 # seconds
    QUEUE_CHECK_PERIOD = 0.3 # seconds

    def __init__(self):
        """
        Only this thread has access to low level GPIO functions. 
        Pin changes are passed through dedicated queue which is handled in a loop.
        Pin state can be changed once every few seconds. Changing pin state more often will put the newest state into pending mode.
        """

        super(self.__class__, self).__init__()
        self.log = logging.getLogger('IOM thread')
        self.ios = TerIO()
        self.events = {
            'heater': IOEvents(self.ios.heater.toggle, self.ios.heater.on, self.ios.heater.off),
            'red': IOEvents(self.ios.lamps['red'].toggle, self.ios.lamps['red'].on, self.ios.lamps['red'].off),
            'white': IOEvents(self.ios.lamps['white'].toggle, self.ios.lamps['white'].on, self.ios.lamps['white'].off),
            'blueL': IOEvents(self.ios.lamps['blueL'].toggle, self.ios.lamps['blueL'].on, self.ios.lamps['blueL'].off),
            'blueR': IOEvents(self.ios.lamps['blueR'].toggle, self.ios.lamps['blueR'].on, self.ios.lamps['blueR'].off)
        }
        self.timers = {}
        for key, val in self.events.items():
            self.timers[key] = {'last': 0, 'pending': None}

        self.ids = {}

    def run(self):
        self.log.info('IO manager thread started')

        while True:
            # Check pending state and handle it
            for io, val in self.timers.items():
                if self.timers[io]['pending'] and self.timers[io]['last'] + self.BUTTON_SUPPRESS_TIME < time():
                    self.timers[io]['last'] = time()
                    action = self.timers[io]['pending']
                    self.events[io][action]()
                    self.timers[io]['pending'] = None
                    print('io: {}, action: {}'.format(io, action))

            # Check queue
            while not iosQ.empty():
                cmd = iosQ.get()
                operation = cmd['type']

                if operation == 'write':
                    data = cmd['data']
                    now = time()
                    for io, action in data:
                        if self.timers[io]['last'] + self.BUTTON_SUPPRESS_TIME < now:
                            print('io: {}, action: {}'.format(io, action))
                            self.timers[io]['last'] = time()
                            self.events[io][action]()
                        else:
                            self.timers[io]['pending'] = action

                elif operation == 'read':
                    data = cmd['data']
                    ret = {}
                    for io in data:
                        if io == 'heater':
                            ret[io] = self.ios.heater.value
                        else:
                            ret[io] = self.ios.lamps[io].value

                    self.ids[cmd['id']] = ret

            sleep(self.QUEUE_CHECK_PERIOD)

    def change(self, *ios):
        iosQ.put({'type': 'write', 'data': list(ios)})

    def getRandomId(self):
        return str(uuid.uuid4())

    def read(self, *ios):
        id = self.getRandomId()
        iosQ.put({'type': 'read', 'data': list(ios), 'id': id})

        while True:
            try:
                state = self.ids[id]
                del self.ids[id]
                return state
            except Exception as e:
                pass
            finally:
                sleep(0.02)


class Reader(QThread):
    def __init__(self, iom):
        super(self.__class__, self).__init__()
        self.iom = iom

    def run(self):
        cnt = 200
        print("T started")
        while cnt >= 0:
            cnt -= 1
            a = self.iom.read('heater')
            # sleep(0.2)


def main():
    iom = IOManager()
    iom.start()

    # ths = []
    # for i in range(10):
    #     t = Reader(iom)
    #     ths.append(t)
    #     t.daemon = True
    #     t.start()

    # for t in ths:
    #     t.wait()

    iom.change(('heater', 'toggle'), ('red', 'off'))

    # iom.change('heater', 'off')
    # iom.change('red', 'on')
    # iom.change('blueR', 'on')

    states = iom.read('heater', 'red', 'blueR')
    print(states)
    iom.change(('blueR', 'on'))
    states = iom.read('red', 'blueR', 'white', 'blueR')
    print(states)

    state = iom.read('heater')

    # sleep(3.5)

if __name__ == '__main__':
    main()