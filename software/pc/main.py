import sys
sys.path.append('gui')

import PyQt5
from PyQt5.QtWidgets import *

import gui
import ter_io


class MainWindow(QMainWindow, gui.Ui_MainWindow):
    def __init__(self):
        super(self.__class__, self).__init__()
        self.setupUi(self)
        self.setFixedSize(self.width(), self.height())
        self.lamps = {}
        self.lamps['czerwona'] = {'btn': self.btnLamp1, 'lab' : self.labLamp1}
        self.lamps['niebieska'] = {'btn': self.btnLamp2, 'lab' : self.labLamp2}
        self.lamps['zielona'] = {'btn': self.btnLamp3, 'lab' : self.labLamp3}
        self.lamps['biala'] = {'btn': self.btnLamp4, 'lab' : self.labLamp4}


        colors = []
        for color, gui in self.lamps.items():
            gui['lab'].setText(color.upper())
            colors.append(color)
        
        self.io = ter_io.TerIO(colors)

        # events
        self.btnHeat.clicked.connect(self.guiHeaterToggle)
        for color, gui in self.lamps.items():
            gui['btn'].clicked.connect(self.makeLampButtonCallback(color))

        # styles
        self.addStyle(self.btnHeat, 'color: white')
        self.addStyle(self.btnLamp1, 'color: white')
        self.addStyle(self.btnLamp2, 'color: white')
        self.addStyle(self.btnLamp3, 'color: white')
        self.addStyle(self.btnLamp4, 'color: white')
        self.toRed(self.btnHeat)
        self.toRed(self.btnLamp1)
        self.toRed(self.btnLamp2)
        self.toRed(self.btnLamp3)
        self.toRed(self.btnLamp4)

    def makeLampButtonCallback(self, color):
        return lambda: self.lampToggle(color)

    def addStyle(self, widget, style):
        widget.setStyleSheet(widget.styleSheet() + style + ';')

    def toRed(self, widget):
        self.addStyle(widget, 'background-color: red')

    def toGreen(self, widget):
        self.addStyle(widget, 'background-color: green')

    def guiHeaterToggle(self):
        self.io.heaterToggle()
        if self.io.heater == True:
            self.btnHeat.setText('ON')
            self.toGreen(self.btnHeat)
        else:
            self.btnHeat.setText('OFF')
            self.toRed(self.btnHeat)

    def lampToggle(self, color):
        self.io.lampToggle(color)
        if self.io.lamps[color]['state'] == True:
            self.lamps[color]['btn'].setText('ON')
            self.toGreen(self.lamps[color]['btn'])
        else:
            self.lamps[color]['btn'].setText('OFF')
            self.toRed(self.lamps[color]['btn'])


def main():
    app = QApplication(sys.argv)
    form = MainWindow()
    form.show()
    # without this, the script exits immediately
    sys.exit(app.exec_())

if __name__ == '__main__':
    main()