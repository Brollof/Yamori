import sys
sys.path.append('gui')
import logging

import PyQt5
from PyQt5.QtWidgets import *
from PyQt5.QtGui import QIcon, QPixmap
from PyQt5.QtCore import *

import gui
import ter_io
import ter_logger
from ter_utils import convertBool
import styles
import icons_rc


class MainWindow(QMainWindow, gui.Ui_MainWindow):
    def __init__(self):
        super(self.__class__, self).__init__()
        self.setupUi(self)
        self.setFixedSize(self.width(), self.height())
        self.log = logging.getLogger('GUI')
        self.lamps = {}
        self.icons = {
            'heat': QIcon(':i_heat.png'),
            'cold': QIcon(':i_cold.png'),
        }

        # map buttons
        self.lamps['blue-L'] = {'btn': self.btnMan1, 'color': 'rgba(0, 0, 255, 30%)'}
        self.lamps['red'] = {'btn': self.btnMan2, 'color': 'rgba(255, 0, 0, 30%)'}
        self.btnHeat = self.btnMan3
        self.lamps['blue-R'] = {'btn': self.btnMan4, 'color': 'rgba(0, 0, 255, 30%)'}
        self.lamps['white'] = {'btn': self.btnMan5, 'color': 'rgba(255, 255, 0, 30%)'}

        self.btnHeat.setIcon(self.icons['cold'])

        # create lamps name array and init GUI labels with it
        colors = []
        for color, gui in self.lamps.items():
            colors.append(color)
        
        self.io = ter_io.TerIO(colors)

        # events
        self.btnHeat.clicked.connect(self.guiHeaterToggle)
        for color, gui in self.lamps.items():
            gui['btn'].clicked.connect(self.createLampButtonCallback(color))

        # styles
        self.initStyles();

    def createLampButtonCallback(self, color):
        return lambda: self.lampToggle(color)

    def initStyles(self):
        for lampName, props in self.lamps.items():
            styles.addStyle(props['btn'], 'background-color: {};'.format(props['color']))

    def guiHeaterToggle(self):
        self.io.heaterToggle()
        if self.io.heater == True:
            self.btnHeat.setIcon(self.icons['heat'])
        else:
            self.btnHeat.setIcon(self.icons['cold'])
        self.log.debug('Heater {}'.format(convertBool(self.io.heater, 'ON', 'OFF')))

    def lampToggle(self, color):
        self.io.lampToggle(color)
        if self.io.lamps[color]['state'] == True:
            styles.setAlpha(self.lamps[color]['btn'], 100)
        else:
            styles.setAlpha(self.lamps[color]['btn'], 30)
        self.log.debug('Lamp {} {}'.format(color, convertBool(self.io.lamps[color]['state'], 'ON', 'OFF')))


def main():
    ter_logger.init()
    ter_logger.printProgramStart()
    app = QApplication(sys.argv)
    # ['windowsvista', 'Windows', 'Fusion']
    # app.setStyle(QStyleFactory.create('Fusion'))
    form = MainWindow()
    form.show()
    sys.exit(app.exec_())

if __name__ == '__main__':
    main()