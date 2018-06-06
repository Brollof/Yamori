import logging
from PyQt5.QtCore import QThread
from threading import Lock, Thread
from time import sleep
import json

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
        try:
            with open(ConfigWorker.FILENAME, 'w') as f:
                json.dump(data, f, indent=2)
        except Exception as e:
            self.log.error("File writing failed")
            self.log.error(e)

    def loadData(self):
        try:
            with open(ConfigWorker.FILENAME, 'r') as f:
                return json.load(f)
        except Exception as e:
            self.log.error("File reading failed")
            self.log.error(e)
            return None


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