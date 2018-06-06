import logging
from PyQt5.QtCore import QThread
from threading import Lock, Thread
from time import sleep
import json
from utils import writeJsonFile, readJsonFile
# DEBUG ONLY
# import ter_logger
# ter_logger.init()

class ConfigWorker(Thread):
    mutex = Lock();
    FILENAME = 'config.json'

    def __init__(self, data=None):
        super(self.__class__, self).__init__()
        self.log = logging.getLogger('CFG_MAN')
        self.data = data

    def saveData(self, data):
        writeJsonFile(ConfigWorker.FILENAME, data, self.log)

    def loadData(self):
        return readJsonFile(ConfigWorker.FILENAME, self.log)

    def run(self):
        if ConfigWorker.mutex.acquire(timeout=1) == False:
            self.log.error('thread is locked: timeout')
            return

        self.log.info('thread started')

        # 1. Save data into file
        self.saveData(self.data)


        # 2. wyslanie konfiguracji lamp (kolory, nazwy) do watku glownego GUI
        #   2.1. Wykorzystanie signal do aktualizacji kontrolek ?
        # 3. wyslanie pozostalych danych do automatu
        self.log.info('thread ended')
        ConfigWorker.mutex.release()



if __name__ == '__main__':
    data = {'asd': 1}
    cw = ConfigWorker(data)
    cw.start()