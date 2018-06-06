import logging
import socket
import json
from PyQt5.QtCore import QThread 
from config_manager import ConfigWorker


class LinkThread(QThread):
    def __init__(self):
        super(self.__class__, self).__init__()
        self.log = logging.getLogger('LINK_T')
        self.host = ''
        self.port = 50007

    def run(self):
        self.log.info('Link thread started')
        while True:
            with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
                s.bind((self.host, self.port))
                self.log.info('Socket binded')
                s.listen(1)
                conn, addr = s.accept()
                self.log.info('Connection accepted')
                with conn:
                    self.log.info('Connected by', addr)
                    while True:
                        data = conn.recv(1024)
                        if not data:
                            self.log.info('Disconnected...')
                            break
                        # else:
                            # conn.sendall(data)

                        if data.decode('ascii') == 'read command':
                            conn.sendall(b'sending current config')
                        else:
                            data = json.loads(data)
                            cw = ConfigWorker(data)
                            cw.start()