import sys
sys.path.append('gui')
import logging
from time import sleep

import PyQt5
from PyQt5.QtWidgets import *
from PyQt5.QtGui import QIcon, QPixmap
from PyQt5.QtCore import QThread, pyqtSignal

import gui
import ter_io
import ter_logger
from ter_utils import convertBool
import styles
import icons_rc
import ter_temp

# debug
import random

MENU_INDICATOR = 'background-color: #ffe0b2; border-radius: 10px'
DIAG_SCREEN_UPDATE_PERIOD = 1 # seconds

# read GPIO state app after restart
# temp limits view

class Stat():
    def __init__(self, name):
        self.name = name
        self.avg = 0
        self.min = 0
        self.max = 0
        self.lastVal = 0
        self.n = 0
        self.sum = 0

    def calcAvg(self, newVal):
        self.n += 1
        self.sum += newVal
        try:
            self.avg = self.sum / self.n
        except ZeroDivisionError:
            print('Cannot divide by 0! n = {}'.format(self.n))

    def update(self, newVal):
        if not self.min and not self.max:
            self.min = newVal
            self.max = newVal

        self.lastVal = newVal
        if newVal > self.max:
            self.max = newVal
        elif newVal < self.min:
            self.min = newVal

        self.calcAvg(newVal)

class DiagThread(QThread):
    update = pyqtSignal(dict)

    def __init__(self, tman):
        super(self.__class__, self).__init__()
        self.log = logging.getLogger('DIAG thread')
        self.temp1Stats = Stat('temp1')
        self.temp2Stats = Stat('temp2')
        self.cpuTemp = Stat('cpuTemp')
        self.humidity = Stat('humidity')
        self.tman = tman

    def run(self):
        self.log.info('Diagnostic thread started')
        while True:
            # read temp sensors
            raw = [v for k, v in self.tman.read().items()]
            # read board temp
            # calculate min, max, avg
            if len(raw) > 0:
                self.temp1Stats.update(raw[0])
            if len(raw) > 1:
                self.temp2Stats.update(raw[1])

            temps = {}
            temps[self.temp1Stats.name] = self.temp1Stats
            temps[self.temp2Stats.name] = self.temp2Stats
            # emit signal to update GUI
            self.update.emit(temps)
            sleep(DIAG_SCREEN_UPDATE_PERIOD)

class MainWindow(QMainWindow, gui.Ui_MainWindow):
    def __init__(self):
        super(self.__class__, self).__init__()
        self.setupUi(self)
        self.setFixedSize(self.width(), self.height())
        self.activeMenu = -1 # current active menu page number
        self.log = logging.getLogger('GUI')
        self.lamps = {}
        self.icons = {
            'heat': QIcon(':i_heat.png'),
            'cold': QIcon(':i_cold.png'),
        }

        # map buttons
        self.lamps['blueL'] = {'btn': self.btnMan1, 'color': 'rgba(0, 0, 255, 30%)'}
        self.lamps['red'] = {'btn': self.btnMan2, 'color': 'rgba(255, 0, 0, 30%)'}
        self.btnHeat = self.btnMan3
        self.lamps['blueR'] = {'btn': self.btnMan4, 'color': 'rgba(0, 0, 255, 30%)'}
        self.lamps['white'] = {'btn': self.btnMan5, 'color': 'rgba(255, 255, 0, 30%)'}
        self.menu = [self.btnManual, self.btnAuto, self.btnDiag]

        self.btnHeat.setIcon(self.icons['cold'])
        
        # events
        self.btnHeat.clicked.connect(self.guiHeaterToggle)
        for color, gui in self.lamps.items():
            gui['btn'].clicked.connect(self.createLampButtonCallback(color))

        self.menu[0].clicked.connect(lambda: self.displayView(0))
        self.menu[1].clicked.connect(lambda: self.displayView(1))
        self.menu[2].clicked.connect(lambda: self.displayView(2))
        self.displayView(0)

        # styles
        self.initStyles();

        self.io = ter_io.IOManager()
        self.tman = ter_temp.TempSensorsManager()

        self.diagThread = DiagThread(self.tman)
        self.diagThread.update.connect(self.updateDiagPage)
        self.diagThread.start()

    def updateDiagPage(self, stats):
        self.labTTemp1.setText('%.1f' % stats['temp1'].lastVal)
        self.labTTemp1Avg.setText('%.1f' % stats['temp1'].avg)
        self.labTTemp1Min.setText('%.1f' % stats['temp1'].min)
        self.labTTemp1Max.setText('%.1f' % stats['temp1'].max)

        self.labTTemp2.setText('%.1f' % stats['temp2'].lastVal)
        self.labTTemp2Avg.setText('%.1f' % stats['temp2'].avg)
        self.labTTemp2Min.setText('%.1f' % stats['temp2'].min)
        self.labTTemp2Max.setText('%.1f' % stats['temp2'].max)

    def displayView(self, viewNum):
        if viewNum == self.activeMenu:
            return

        styles.removeStyle(self.menu[self.activeMenu], MENU_INDICATOR)
        styles.addStyle(self.menu[viewNum], MENU_INDICATOR)
        self.mainView.setCurrentIndex(viewNum)
        self.activeMenu = viewNum;

    def createLampButtonCallback(self, color):
        return lambda: self.lampToggle(color)

    def initStyles(self):
        for lampName, props in self.lamps.items():
            styles.addStyle(props['btn'], 'background-color: {};'.format(props['color']))
        # self.menuFrame.setStyleSheet('border: 4px solid #ffe0b2')

    def guiHeaterToggle(self):
        self.io.write(('heater', 'toggle'))
        state = self.io.read('heater')['heater']
        if state == True:
            self.btnHeat.setIcon(self.icons['heat'])
        else:
            self.btnHeat.setIcon(self.icons['cold'])
        self.log.debug('Heater {}'.format(convertBool(state, 'ON', 'OFF')))

    def lampToggle(self, lamp):
        self.io.write((lamp, 'toggle'))
        state = self.io.read(lamp)[lamp]
        if state == True:
            styles.setAlpha(self.lamps[lamp]['btn'], 100)
        else:
            styles.setAlpha(self.lamps[lamp]['btn'], 30)
        self.log.debug('Lamp {} {}'.format(lamp, convertBool(state, 'ON', 'OFF')))


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