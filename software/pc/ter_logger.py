import sys
import logging

moduleInitialized = False

def init():
    global moduleInitialized
    if moduleInitialized:
        return

    moduleInitialized = True
    # logging.basicConfig(format='%(asctime)s [%(name)s]|%(levelname)s| %(message)s', filename='terrarium.log',level=logging.DEBUG)
    root = logging.getLogger()
    root.setLevel(logging.DEBUG)

    formatter = logging.Formatter('%(asctime)s [%(name)s]|%(levelname)s| %(message)s')

    fh = logging.FileHandler('terr.log')
    fh.setLevel(logging.DEBUG)
    fh.setFormatter(formatter)

    ch = logging.StreamHandler(sys.stdout)
    ch.setLevel(logging.DEBUG)
    ch.setFormatter(formatter)
    root.addHandler(ch)
    root.addHandler(fh)

    printProgramStart()

def printProgramStart():
    logging.info('=================================================')
    logging.info('=================================================')
    logging.info('=================================================')
    logging.info('Application started')

def printProgramClosed():
    logging.info('Application terminated')
    
init()