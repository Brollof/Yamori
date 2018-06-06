import logging
from utils import convertBool
from PyQt5.QtCore import QThread, QSemaphore
from time import sleep, time
from queue import Queue
import uuid
import os
import settings

if settings.getPlatform() == 'rpi':
    from gpiozero import DigitalOutputDevice
else:
    from dummy import DigitalOutputDevice

class AsyncIO(QThread):
    def __init__(self, sleepTime, onRead, onWrite, onStart=None, onStop=None):
        super(self.__class__, self).__init__()
        self.queue = Queue()
        self.sleepTime = sleepTime
        self.onStart = onStart
        self.onStop = onStop
        self.onRead = onRead
        self.onWrite = onWrite
        self.stop = False
        self.ids = {}
        self.start()

    def __getRandomId(self):
        return str(uuid.uuid4())

    def write(self, *data):
        self.queue.put({'type': 'write', 'data': list(data)})

    def read(self, *data):
        id = self.__getRandomId()
        sem = QSemaphore(1)
        sem.acquire()
        self.queue.put({'type': 'read', 'data': list(data), 'id': id, 'sem': sem})
        # wait for release the semaphore
        sem.acquire()
        state = self.ids[id]
        del self.ids[id]
        return state

    def run(self):
        if self.onStart:
            self.onStart()

        while self.stop == False:
            while not self.queue.empty():
                cmd = self.queue.get()
                operation = cmd['type']

                if operation == 'write':
                    self.onWrite(cmd['data'])

                elif operation == 'read':
                    self.ids[cmd['id']] = self.onRead(cmd['data'])
                    cmd['sem'].release()

            sleep(self.sleepTime)

    def close(self):
        self.stop = True
        self.wait()
        if self.onStop:
            self.onStop()

class TerIO():
    def __init__(self):
        self.lamps = {
            'red': DigitalOutputDevice(26, active_high=False, initial_value=False),
            'white': DigitalOutputDevice(19, active_high=False, initial_value=False),
            'blueL': DigitalOutputDevice(13, active_high=False, initial_value=False),
            'blueR': DigitalOutputDevice(6, active_high=False, initial_value=False)
        }
        self.heater = DigitalOutputDevice(5, active_high=False, initial_value=False)
        self.log = logging.getLogger('IO')
        self.log.info('IO init')



class IOEvents():
    def __init__(self, toggle, on, off):
        self.actions = {
            'toggle': toggle,
            'on': on,
            'off': off
        }
    def __getitem__(self, item):
        return self.actions[item]

class IOManager():
    BUTTON_SUPPRESS_TIME = 2 # seconds
    QUEUE_CHECK_PERIOD = 0.05 # seconds

    def __init__(self):
        """
        Only this thread has access to low level GPIO functions. 
        Pin changes are passed through dedicated queue which is handled in a loop.
        Pin state can be changed once every few seconds. Changing pin state more often will put the newest state into pending mode.
        """

        super(self.__class__, self).__init__()
        self.log = logging.getLogger('IOM_T')
        self.asyncIO = AsyncIO(self.QUEUE_CHECK_PERIOD, self.__onRead, self.__onWrite, self.__onStart)
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
            self.timers[key] = {'last': 0}

    def __onRead(self, data):
        ret = {}
        for io in data:
            if io == 'heater':
                ret[io] = self.ios.heater.value
            else:
                ret[io] = self.ios.lamps[io].value
        return ret

    def __onWrite(self, data):
        now = time()
        for io, action in data:
            if self.timers[io]['last'] + self.BUTTON_SUPPRESS_TIME < now:
                print('io: {}, action: {}'.format(io, action))
                self.timers[io]['last'] = time()
                self.events[io][action]()

    def __onStart(self):
        self.log.info('IO manager thread started')

    def read(self, ios):
        return self.asyncIO.read(ios)

    def write(self, ios):
        self.asyncIO.write(ios)


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

    # iom.change(('heater', 'toggle'), ('red', 'off'))

    # states = iom.read('heater', 'red', 'blueR')
    # print(states)
    # iom.change(('blueR', 'on'))
    states = iom.read('red', 'blueR', 'white', 'blueR')
    states = iom.read('red', 'blueR', 'white', 'blueR')
    states = iom.read('red', 'blueR', 'white', 'blueR')
    print(states)






    # sleep(3.5)

if __name__ == '__main__':
    main()