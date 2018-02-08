import logging
from ter_utils import convertBool

class TerIO():
    def __init__(self, lampNames):
        self.heater = False
        self.lamps = {}
        self.log = logging.getLogger('IO')
        for name in lampNames:
            self.lamps[name] = {'state': False, 'pin': None}

        self.log.info('IO init')

    def heaterOn(self):
        self.heater = True

    def heaterOff(self):
        self.heater = False

    def lampToggle(self, name):
        if self.lamps[name]['state'] == True:
            self.lamps[name]['state'] = False
        else:
            self.lamps[name]['state'] = True
        self.log.debug('Lamp {} {}'.format(name, convertBool(self.lamps[name]['state'], 'ON', 'OFF')))

    def heaterToggle(self):
        if self.heater == True:
            self.heaterOff()
        else:
            self.heaterOn()
        self.log.debug('Heater {}'.format(convertBool(self.heater, 'ON', 'OFF')))

    def getLamp(self, n):
        return self.lamps[n]


def main():
    io = TerIO(['red', 'blue'])



if __name__ == '__main__':
    main()