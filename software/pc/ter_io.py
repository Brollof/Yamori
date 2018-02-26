import logging
from ter_utils import convertBool
from PyQt5.QtCore import QThread
from time import sleep

class TerIO():
    def __init__(self, lampNames):
        self.lamps = {}
        self.log = logging.getLogger('IO')
        self.heater = {'state': False, 'pin': None}
        for name in lampNames:
            self.lamps[name] = {'state': False, 'pin': None}

        self.log.info('IO init')

    def heaterOn(self):
        self.heater['state'] = True

    def heaterOff(self):
        self.heater['state'] = False

    def lampToggle(self, name):
        if self.lamps[name]['state'] == True:
            self.lamps[name]['state'] = False
        else:
            self.lamps[name]['state'] = True
        self.log.debug('Lamp {} {}'.format(name, convertBool(self.lamps[name]['state'], 'ON', 'OFF')))

    def heaterToggle(self):
        if self.heater['state'] == True:
            self.heaterOff()
        else:
            self.heaterOn()
        self.log.debug('Heater {}'.format(convertBool(self.heater['state'], 'ON', 'OFF')))

    def getLampState(self, name):
        return self.lamps[name]['state']

    def getHeaterState(self):
        return self.heater['state']


class IOManager(QThread):
    def __init__(self):
        super(self.__class__, self).__init__()
        self.log = logging.getLogger('IOM thread')

    def run(self):
        self.log.info('IO manager thread started')
        while True:
            sleep(1)

def main():
    io = TerIO(['red', 'blue'])



if __name__ == '__main__':
    main()