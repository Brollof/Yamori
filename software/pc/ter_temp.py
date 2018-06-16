from terio.async import AsyncIO
import logging
import ds18b20

class TempSensorsManager():
    QUEUE_CHECK_PERIOD = 0.2 # seconds

    def __init__(self):
        self.log = logging.getLogger('TEMP_T')
        self.ds = ds18b20.DS18B20()
        self.asyncIO = AsyncIO(self.QUEUE_CHECK_PERIOD, self.__onRead, None, self.__onStart)

    def __onRead(self, data):
        return self.ds.readTemps()

    def __onStart(self):
        self.log.info('Temp sensor thread started')

    def read(self):
        return self.asyncIO.read(None)

    def close(self):
        self.asyncIO.close()

def main():
    from time import sleep
    tman = TempSensorsManager()
    print(tman.read())
    sleep(1)
    tman.close()

if __name__ == '__main__':
    main()