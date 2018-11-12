import sys
sys.path.append('gui')
import logging
from time import sleep

import PyQt5
from PyQt5.QtWidgets import *
from PyQt5.QtGui import QIcon, QPixmap
from PyQt5.QtCore import QThread, pyqtSignal

import ter_logger
from config import config

import gui

from utils import convertBool
import styles
import icons_rc
import ter_temp
import link
from diagnostic import DiagThread
from event_handler import EventHandler
import gui_clicker
from config import config_ex

MENU_INDICATOR = 'background-color: #ffe0b2; border-radius: 10px'

class MainWindow(QMainWindow, gui.Ui_MainWindow):
    def __init__(self):
        super(self.__class__, self).__init__()
        self.setupUi(self)
        self.setFixedSize(self.width(), self.height())
        self.activeMenu = -1 # current active menu page number
        self.log = logging.getLogger('GUI')
        self.lamps = {}
        self.heater  = None
        self.icons = {
            'heat': QIcon(':i_heat.png'),
            'cold': QIcon(':i_cold.png'),
        }

        link.addCommand("TER_READ", config_ex.getJson)
        self.linkThread = link.LinkThread()
        self.linkThread.start()

        config_ex.configWorkerInit(self.reinitButtons)

        if config_ex.isInitialized() == True:
            config_ex.initDevices()
            self.initButtons(config_ex.getButtonsConfig())
            self.log.info("Device is initialized!")
        else:
            self.log.warning("Device NOT initialized!")
            self.showInitScreen()
            return
        
        self.menu = [self.btnManual, self.btnAuto, self.btnDiag]
        self.menu[0].clicked.connect(lambda: self.displayView(0))
        self.menu[1].clicked.connect(lambda: self.displayView(1))
        self.menu[2].clicked.connect(lambda: self.displayView(2))
        self.displayView(0)

        self.initStyles()
        self.tman = ter_temp.TempSensorsManager()

        self.guiClicker = gui_clicker.GuiClicker()
        self.guiClicker.setUpdateSignal(self.updateButtonStyle)
        self.guiClicker.start()

        self.diagThread = DiagThread(self.tman)
        self.diagThread.update.connect(self.updateDiagPage)
        self.diagThread.start()

        self.evt = EventHandler(config_ex.loadData(), self.guiClicker, self.diagThread)
        self.evt.start()

        if config.getPlatform() == 'rpi':
            self.showFullScreen()

    def initButtons(self, config):
        buttons = [self.btnMan1, self.btnMan2, self.btnMan4, self.btnMan5]

        for cfg in config:
            if cfg['type'] == 'LAMP':
                color = 'rgba' + str(cfg['color'])[:-1] + ', 30%)'
                self.lamps[cfg['name']] = {'btn': buttons.pop(0), 'color': color}
            elif cfg['type'] == 'CABLE':
                self.heater = {'name': cfg['name'], 'btn': self.btnMan3}
            else:
                self.log.error('Skipping device "%s"' %cfg['type'])

        if self.heater:
            self.heater['btn'].clicked.connect(self.guiHeaterToggle)
            self.heater['btn'].setIcon(self.icons['cold'])

        for name, gui in self.lamps.items():
            gui['btn'].clicked.connect(self.createLampButtonCallback(name))

    def updateDiagPage(self, stats):
        self.labTTemp1.setText('%.1f' % stats['temp1'].lastVal)
        self.labTTemp1Avg.setText('%.1f' % stats['temp1'].avg)
        self.labTTemp1Min.setText('%.1f' % stats['temp1'].min)
        self.labTTemp1Max.setText('%.1f' % stats['temp1'].max)

        self.labTTemp2.setText('%.1f' % stats['temp2'].lastVal)
        self.labTTemp2Avg.setText('%.1f' % stats['temp2'].avg)
        self.labTTemp2Min.setText('%.1f' % stats['temp2'].min)
        self.labTTemp2Max.setText('%.1f' % stats['temp2'].max)

    def reinitButtons(self, data):
        self.log.debug('Updating GUI buttons with data')
        self.log.debug(data)

        # initialize gui variables
        self.lamps = {}
        self.heater = None
        buttons = [self.btnMan1, self.btnMan2, self.btnMan3, self.btnMan4, self.btnMan5]

        # remove buttons callbacks
        for btn in buttons:
            try:
                btn.clicked.disconnect()
            except Exception:
                pass

        # create gui buttons
        self.initButtons(data)
        self.initStyles()

    def updateButtonStyle(self, data):
        for dev, state in data.items():
            if dev in self.lamps:
                self.guiLampStyle(dev, state)
            elif dev == self.heater['name']:
                self.guiHeaterStyle(state)
            else:
                self.log.warning('Device "%s" is not available on GUI' %dev)

    def displayView(self, viewNum):
        if viewNum == self.activeMenu:
            return

        styles.removeStyle(self.menu[self.activeMenu], MENU_INDICATOR)
        styles.addStyle(self.menu[viewNum], MENU_INDICATOR)
        self.mainView.setCurrentIndex(viewNum)
        self.activeMenu = viewNum

    def createLampButtonCallback(self, color):
        return lambda: self.guiLampToggle(color)

    def initStyles(self):
        for lampName, props in self.lamps.items():
            styles.addStyle(props['btn'], 'background-color: {};'.format(props['color']))
        # self.menuFrame.setStyleSheet('border: 4px solid #ffe0b2')

    def guiHeaterStyle(self, state):
        if self.heater:
            self.log.debug('Updating heater to {}'.format(state))
            if state in [True, 'on']:
                self.heater['btn'].setIcon(self.icons['heat'])
            else:
                self.heater['btn'].setIcon(self.icons['cold'])
        else:
            self.log.warning('Heater is not present!')

    def guiHeaterToggle(self):
        self.guiClicker.set(self.heater['name'], 'toggle')

    def guiLampStyle(self, lamp, state):
        self.log.debug('updating lamp "{}" to {}'.format(lamp, state))
        if state in [True, 'on']:
            styles.setAlpha(self.lamps[lamp]['btn'], 100)
        else:
            styles.setAlpha(self.lamps[lamp]['btn'], 30)

    def guiLampToggle(self, lamp):
        self.guiClicker.set(lamp, 'toggle')

    def showInitScreen(self):
        self.verticalLayoutWidget.hide() # hides all controls
        self.initLabel = QLabel(self.centralwidget)
        self.initLabel.setObjectName("initLabel")
        self.initLabel.setText('ZAINICJALIZUJ\nURZĄDZENIE')
        self.initLabel.setStyleSheet('font-size: 80px; color: darkblue')
        self.initLabel.setAlignment(PyQt5.QtCore.Qt.AlignHCenter | PyQt5.QtCore.Qt.AlignVCenter)
        self.initLabel.setFixedSize(self.width(), self.height())


def main():
    app = QApplication(sys.argv)
    # ['windowsvista', 'Windows', 'Fusion']
    # app.setStyle(QStyleFactory.create('Fusion'))
    form = MainWindow()
    form.show()
    sys.exit(app.exec_())

if __name__ == '__main__':
    main()