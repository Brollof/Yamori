from time import sleep
import datetime
from queue import Queue
from PyQt5.QtCore import QThread, pyqtSignal
import logging

log = logging.getLogger('EVT')
queue = Queue()

def reinit(data):
    queue.put(data)

class EventHandler(QThread):
    SLEEP_TIME = 0.2 
    updateButtonsSig = pyqtSignal(dict)

    def __init__(self, data, io, updateButtons):
        super(self.__class__, self).__init__()
        self.__init(data)
        self.__io = io
        self.__enabled = True
        self.updateButtonsSig.connect(updateButtons)
        log.debug('thread initialized')

    def __getCurrentState(self, dev):
        events = self.events[dev]
        if events == []:
            return False
        now = datetime.datetime.now().time()
        devState = events[-1]['State']
        for evt in events:
            if self.__getEventTime(evt) <= now:
                devState = evt['State']

        return devState

    def __checkLimits(self):
        pass

    def __init(self, data):
        self.cfg = data['Config']

        self.events = {}
        for name in data['Devices']:
            self.events[name] = data['Devices'][name]['Events']

        self.currentStates = {key: None for key in self.events}

        log.debug('Config:')
        log.debug(self.cfg)

        log.debug('Evt:')
        log.debug(self.events)

    def __checkNewData(self):
        if not queue.empty():
            data = queue.get()
            log.debug('Data received:')
            log.debug(data)
            self.__init(data)

    def __getEventTime(self, event):
        switchTime = event['Time']
        h = int(switchTime[:2])
        m = int(switchTime[-2:])
        return datetime.time(h, m)

    def __checkEvents(self):
        now = datetime.datetime.now().time()
        for dev in self.events:
            newState = self.__getCurrentState(dev)
            if newState != self.currentStates[dev]:
                self.currentStates[dev] = newState
                stype = 'on' if newState else 'off'
                self.__io.write((dev, stype))
                self.updateButtonsSig.emit({dev: stype})

    def run(self):
        log.info('thread started')
        n = 20
        while n:
            # n -= 1
            self.__checkNewData()
            if self.__enabled == True:
                self.__checkEvents()
            self.__checkLimits()
            # break
            sleep(EventHandler.SLEEP_TIME)

        log.critical('thread ended!')

if __name__ == '__main__':
    pass
    # import sys
    # import ter_logger
    # sys.path.append('..')
    # from config import config_ex
    # evt = EventHandler(config_ex.loadData(), None)
    # evt.start()