from PyQt5.QtCore import QThread, QSemaphore
from queue import Queue
from time import sleep
import uuid

class AsyncIO(QThread):
    def __init__(self, sleepTime, onRead, onWrite, onStart=None, onStop=None):
        super(self.__class__, self).__init__()
        self.queue = Queue()
        self.sleepTime = sleepTime
        self.onStart = onStart
        self.onStop = onStop
        self.onRead = onRead
        self.onWrite = onWrite
        self.stop = False
        self.ids = {}
        self.start()

    def __getRandomId(self):
        return str(uuid.uuid4())

    def write(self, *data):
        self.queue.put({'type': 'write', 'data': list(data)})

    def read(self, *data):
        id = self.__getRandomId()
        sem = QSemaphore(1)
        sem.acquire()
        self.queue.put({'type': 'read', 'data': list(data), 'id': id, 'sem': sem})
        # wait for release the semaphore
        sem.acquire()
        state = self.ids[id]
        del self.ids[id]
        return state

    def run(self):
        if self.onStart:
            self.onStart()

        while self.stop == False:
            while not self.queue.empty():
                cmd = self.queue.get()
                operation = cmd['type']

                if operation == 'write':
                    self.onWrite(cmd['data'])

                elif operation == 'read':
                    self.ids[cmd['id']] = self.onRead(cmd['data'])
                    cmd['sem'].release()

            sleep(self.sleepTime)

    def close(self):
        self.stop = True
        self.wait()
        if self.onStop:
            self.onStop()

if __name__ == '__main__':
    a = AsyncIO(1, None, None)