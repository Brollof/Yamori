from PyQt5.QtCore import QThread, pyqtSignal
import logging
from time import sleep
import ter_temp

DIAG_SCREEN_UPDATE_PERIOD = 1 # seconds

class Stats():
    def __init__(self):
        self.avg = 0
        self.min = 0
        self.max = 0
        self.lastVal = 0
        self.n = 0
        self.sum = 0

    def calcAvg(self, newVal):
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

        self.n += 1
        self.calcAvg(newVal)


class Sensor():
    def __init__(self, name=None, gui=False, read=None):
        self.name = name
        self.stats = Stats()
        self.gui = gui
        self.readCallback = read

    def update(self):
        self.stats.update(self.read())

    def read(self):
        return int(self.readCallback()) if self.readCallback else 0


class DiagThread(QThread):
    update = pyqtSignal(dict)

    def __init__(self):
        super(self.__class__, self).__init__()
        self.log = logging.getLogger('DIAG_T')
        self.tman = ter_temp.TempSensorsManager()
        self.sensors = {}
        # create temperature sensors
        for name in self.tman.names:
            self.addSensor(name, None)

        self.addSensor('cpu', self.tman.readCpu)

    def addSensor(self, name, read=None):
        self.sensors[name] = Sensor(name=name, gui=True, read=read)

    def run(self):
        self.log.info('Diagnostic thread started')
        while True:
            # Update temprature sensor manually
            # Before update translate raw sensor name to api sensor name
            for name, value in self.tman.readEnv().items():
                name = self.tman.translate(name)
                self.sensors[name].stats.update(value)

            self.sensors['cpu'].update()

            self.update.emit(self.sensors)
            sleep(DIAG_SCREEN_UPDATE_PERIOD)


if __name__ == '__main__':
    sensor = Sensor()
    sensor.stats.update(20)
    sensor.stats.update(10)
    print(sensor.stats)