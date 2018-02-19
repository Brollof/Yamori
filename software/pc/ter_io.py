import logging
from ter_utils import convertBool

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


def main():
    io = TerIO(['red', 'blue'])



if __name__ == '__main__':
    main()