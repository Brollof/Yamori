import sys
sys.path.append('gui')

import PyQt5
from PyQt5.QtWidgets import *

import gui

class MainWindow(QMainWindow, gui.Ui_MainWindow):
    def __init__(self):
        super(self.__class__, self).__init__()
        self.setupUi(self)

        self.pushButton.clicked.connect(lambda: self.label.setText('asd'))


def main():
    app = QApplication(sys.argv)
    form = MainWindow()
    form.show()
    # without this, the script exits immediately
    sys.exit(app.exec_())

if __name__ == '__main__':
    main()