import logging
import socket
import json
from PyQt5.QtCore import QThread
from config.config_ex import ConfigWorker

MAX_CMD_NAME_LEN = 10
COMMANDS = {}

log = logging.getLogger('LINK')

def addCommand(name, callback):
    if len(name) > MAX_CMD_NAME_LEN:
        raise OverflowError
    COMMANDS[name] = callback

def getResponse(name):
    for key in COMMANDS:
        if key == name:
            return COMMANDS[name]()

# QThread is used instead of Thread
# QT closes this thread when the application is closed
class LinkThread(QThread):
    def __init__(self):
        super(self.__class__, self).__init__()
        self.host = ''
        self.port = 50007

    def run(self):
        log.info('Link thread started')
        while True:
            with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
                s.bind((self.host, self.port))
                log.info('Socket binded')
                s.listen(1)
                # socket.setdefaulttimeout(1) # non blocking accept
                conn, addr = s.accept()
                log.info('Connection accepted')
                with conn:
                    log.info('Connected by {}'.format(addr))
                    while True:
                        data = conn.recv(1024*8)
                        if not data:
                            log.info('Disconnected...')
                            break

                        if len(data) > MAX_CMD_NAME_LEN:
                            data = json.loads(data)
                            cw = ConfigWorker(data)
                            cw.start()
                        else:
                            data = data.decode('ascii')
                            resposne = getResponse(data)
                            if resposne:
                                log.info('Executing command: "{}"'.format(data))
                                conn.sendall(resposne.encode())
                            else:
                                log.error('Command "{}" not found!'.format(data))

if __name__ == '__main__':
    pass