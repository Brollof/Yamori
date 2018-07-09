from PyQt5.QtCore import QThread, pyqtSignal
from queue import Queue
from time import sleep
from terio.manager import IOManager

class GuiClicker(QThread):
    updateButtonsSig = pyqtSignal(dict)

    def __init__(self):
        super(self.__class__, self).__init__()
        self.io = IOManager()
        self.queue = Queue()

    def setUpdateSignal(self, callback):
        self.updateButtonsSig.connect(callback)

    def set(self, dev, state):
        self.queue.put((dev, state))

    def setGuiIO(self, data):
        dev, state = data
        self.io.write(data)
        state = self.io.read(dev)[dev]
        self.updateButtonsSig.emit({dev: state})

    def run(self):
        while True:
            while not self.queue.empty():
                data = self.queue.get()
                self.setGuiIO(data)

            sleep(0.1)

if __name__ == '__main__':
    g = GuiClicker()