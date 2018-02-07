import logging
from ter_utils import convertBool

class TerIO():
    def __init__(self, colors):
        self.heater = False
        self.lamps = {}
        self.log = logging.getLogger('IO')
        for color in colors:
            self.lamps[color] = {'state': False, 'pin': None}

        print('IO init')

    def heaterOn(self):
        print('Heater on')
        self.heater = True

    def heaterOff(self):
        print('Heater off')
        self.heater = False

    def lampToggle(self, lampColor):
        if self.lamps[lampColor]['state'] == True:
            self.lamps[lampColor]['state'] = False
        else:
            self.lamps[lampColor]['state'] = True
        self.log.debug('Lamp {} {}'.format(lampColor, convertBool(self.lamps[lampColor]['state'], 'ON', 'OFF')))
        print('Lamp {} {}'.format(lampColor, 'ON' if self.lamps[lampColor]['state'] else 'OFF'))


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