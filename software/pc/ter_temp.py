from terio.async import AsyncIO
import logging
import ds18b20
from config import config
import subprocess

class TempSensorsManager():
    QUEUE_CHECK_PERIOD = 0.2 # seconds

    def __init__(self):
        self.log = logging.getLogger('TEMP_T')
        self.bus = ds18b20.DS18B20()
        self.asyncIO = AsyncIO(self.QUEUE_CHECK_PERIOD, self.__onRead, None, self.__onStart)
        # create translator between raw device name and human readable name
        self.names = {'t' + str(i + 1): rawName for i, rawName in enumerate(self.bus.devices)}

    def translate(self, name):
        for friendlyName, rawName in self.names.items():
            if name == friendlyName:
                return rawName
            elif name == rawName:
                return friendlyName

    def __onRead(self, data):
        return self.bus.readTemps()

    def __onStart(self):
        self.log.info('Temp sensor thread started')

    def readEnv(self):
        return self.asyncIO.read(None)

    def readCpu(self):
        if config.getPlatform() == 'rpi':
            try:
                result = subprocess.run('vcgencmd measure_temp', stdout=subprocess.PIPE, shell=True, check=True, universal_newlines=True)
                return float(result.stdout.strip()[5:-2])
            except Exception as e:
                self.log.error('Cannot read CPU temp: {}'.format(e))
                return 0
        else:
            return 42.5

    def close(self):
        self.asyncIO.close()

def main():
    from time import sleep
    tman = TempSensorsManager()
    print(tman.readEnv())
    sleep(1)
    tman.close()

if __name__ == '__main__':
    main()