from threading import Lock
import utils
import logging
import os

filename = 'settings.json'
mutex = Lock()
log = logging.getLogger('SET')
settings = None
moduleInitialized = False

def readSettings():
    if mutex.acquire(timeout=1) == False:
        log.error('mutex timeout')
        return
    data = utils.readJsonFile(filename, log)
    mutex.release()
    return data

def writeSettings(data):
    if mutex.acquire(timeout=1) == False:
        log.error('mutex timeout')
        return

    utils.writeJsonFile(filename, data, log)
    mutex.release()

def init():
    global moduleInitialized
    if moduleInitialized: # only one call is allowed
        return

    moduleInitialized = True
    global settings
    settings = readSettings()
    if not settings:
        raise ValueError("Settings file doesn't exist!")

    if os.name in ["posix", "unix"]:
        settings['Platform'] = 'rpi'
    else:
        settings['Platform'] = 'pc'

    log.info('Settings module initialized')

def isInitialized():
    return settings['Initialized']

def getPlatform():
    return settings['Platform']

init()

if __name__ == '__main__':
    plat = getPlatform()
    print(plat)