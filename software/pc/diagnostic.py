from PyQt5.QtCore import QThread, pyqtSignal
import logging
from time import sleep

DIAG_SCREEN_UPDATE_PERIOD = 1 # seconds

class Stat():
    def __init__(self, name):
        self.name = name
        self.avg = 0
        self.min = 0
        self.max = 0
        self.lastVal = 0
        self.n = 0
        self.sum = 0

    def calcAvg(self, newVal):
        self.n += 1
        self.sum += newVal
        try:
            self.avg = self.sum / self.n
        except ZeroDivisionError:
            print('Cannot divide by 0! n = {}'.format(self.n))

    def update(self, newVal):
        if not self.min and not self.max:
            self.min = newVal
            self.max = newVal

        self.lastVal = newVal
        if newVal > self.max:
            self.max = newVal
        elif newVal < self.min:
            self.min = newVal

        self.calcAvg(newVal)

class DiagThread(QThread):
    update = pyqtSignal(dict)

    def __init__(self, tman):
        super(self.__class__, self).__init__()
        self.log = logging.getLogger('DIAG thread')
        self.temp1Stats = Stat('temp1')
        self.temp2Stats = Stat('temp2')
        self.cpuTemp = Stat('cpuTemp')
        self.humidity = Stat('humidity')
        self.tman = tman

    def run(self):
        self.log.info('Diagnostic thread started')
        while True:
            # read temp sensors
            raw = [v for k, v in self.tman.read().items()]
            # read board temp
            # calculate min, max, avg
            if len(raw) > 0:
                self.temp1Stats.update(raw[0])
            if len(raw) > 1:
                self.temp2Stats.update(raw[1])

            temps = {}
            temps[self.temp1Stats.name] = self.temp1Stats
            temps[self.temp2Stats.name] = self.temp2Stats
            # emit signal to update GUI
            self.update.emit(temps)
            sleep(DIAG_SCREEN_UPDATE_PERIOD)