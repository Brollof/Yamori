from time import sleep
from queue import Queue
from PyQt5.QtCore import QThread
import logging

log = logging.getLogger('EVT')
queue = Queue()

def send(data):
    queue.put(data)

class EventHandler(QThread):
    SLEEP_TIME = 0.2 

    def __init__(self, data=None):
        super(self.__class__, self).__init__()
        if data:
            self.init(data)
        log.debug('thread initialized')

    def __filterEmpty(self, data):
        return dict(filter(lambda it: it[1] != [], data.items()))

    def init(self, data):
        self.cfg = data.pop('config')
        self.evt = self.__filterEmpty(data)
        for name in self.evt:
            if self.evt[name] == []:
                del self.evt[name]

        log.debug('Config:')
        log.debug(self.cfg)

        log.debug('Evt:')
        log.debug(self.evt)

    def run(self):
        log.info('thread started')
        while True:
            if not queue.empty():
                data = queue.get()
                log.debug('Data received:')
                log.debug(data)
                self.init(data)
            sleep(EventHandler.SLEEP_TIME)

        log.critical('thread ended!')

if __name__ == '__main__':
    pass