import logging

def init():
    logging.basicConfig(format='%(asctime)s [%(name)s]|%(levelname)s| %(message)s', filename='terrarium.log',level=logging.DEBUG)

def printProgramStart():
    logging.info('=================================================')
    logging.info('=================================================')
    logging.info('=================================================')
    logging.info('Application started')

def printProgramClosed():
    logging.info('Application terminated')
    
def main():
    init();

if __name__ == '__main__':
    main()