import logging
from threading import Lock
from utils import writeJsonFile, readJsonFile
from PyQt5.QtCore import QThread, pyqtSignal
import os
from terio import device
import event_handler
import json
import time

filename = 'config_ex.json'
filepath = os.path.join(os.path.dirname(__file__), filename)

guiAction = None

log = logging.getLogger('CFG_EX')

def saveData(data):
    writeJsonFile(filepath, data, log)

def loadData():
    return readJsonFile(filepath, log)

def getJson():
    data = loadData()
    return json.dumps(data)

def configWorkerInit(action):
    global guiAction
    guiAction = action

def isInitialized():
    try:
        devices = loadData()['Initialized']
        return True
    except Exception:
        return False

def getButtonsConfig(devices=None):
    if not devices:
        devices = loadData()['Devices']

    data = []
    lampCnt = 0
    cableCnt = 0
    for name, cfg in devices.items():
        record = {}
        record['name'] = name
        record['type'] = cfg['Type']
        if cfg['Type'] == 'LAMP' and lampCnt < 4:
            r, g, b = cfg['Color']['R'], cfg['Color']['G'], cfg['Color']['B']
            record['color'] = (r, g, b)
            lampCnt += 1
            data.append(record)
        elif cfg['Type'] == 'CABLE' and cableCnt < 1:
            cableCnt += 1
            data.append(record)
        if len(data) == 5:
            break   

    return data

def initDevices(devices=None):
    if not devices:
        devices = loadData()['Devices']

    device.clear()
    for name, config in devices.items():
        r, g, b = config['Color']['R'], config['Color']['G'], config['Color']['B']
        dev = device.Device(name, config['Slot'], config['Type'], (r, g, b))
        device.add(dev)

class ConfigWorker(QThread):
    mutex = Lock();
    update = pyqtSignal(list)

    def __init__(self, data=None):
        super(self.__class__, self).__init__()
        self.data = data
        self.update.connect(guiAction)

    def run(self):
        if ConfigWorker.mutex.acquire(timeout=1) == False:
            log.error('thread is locked: timeout')
            return

        log.info('thread started')

        # 1. Save data into file
        self.data['Initialized'] = True
        saveData(self.data)

        # 2. Init devices
        devices = self.data['Devices']
        initDevices(devices)
        time.sleep(1) # wait some time after GPIOs reinit

        # 3. Update GUI with new config
        self.update.emit(getButtonsConfig(devices))

        # 4. Re-initialize event handler with new data
        event_handler.reinit(self.data)

        ##
        log.info('thread ended')
        ConfigWorker.mutex.release()



if __name__ == '__main__':
    pass