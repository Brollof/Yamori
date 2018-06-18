from threading import Lock
import sys
sys.path.append('..')
import utils
import logging
import os

filename = 'config.json'
filepath = os.path.join(os.path.dirname(__file__), filename)

mutex = Lock()
log = logging.getLogger('CFG')
config = None
moduleInitialized = False

def readConfig():
    if mutex.acquire(timeout=1) == False:
        log.error('mutex timeout')
        return
    data = utils.readJsonFile(filepath, log)
    mutex.release()
    return data

def writeConfig(data):
    if mutex.acquire(timeout=1) == False:
        log.error('mutex timeout')
        return

    utils.writeJsonFile(filepath, data, log)
    mutex.release()

def init():
    global moduleInitialized
    if moduleInitialized: # only one call is allowed
        return

    moduleInitialized = True
    global config
    config = readConfig()
    if not config:
        log.warning('Config file is empty!')

    if os.name in ["posix", "unix"]:
        config['Platform'] = 'rpi'
    else:
        config['Platform'] = 'pc'

    log.info('OS detected: {}'.format(config['Platform']))
    log.info('Config module initialized')

def isInitialized():
    try:
        dev = config['Devices']
        return True
    except Exception:
        return False

def getPlatform():
    return config['Platform']




init()

if __name__ == '__main__':
    pass
    x = isInitialized()
    print(x)
