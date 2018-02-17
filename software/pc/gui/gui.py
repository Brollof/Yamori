# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'gui.ui'
#
# Created by: PyQt5 UI code generator 5.10
#
# WARNING! All changes made in this file will be lost!

from PyQt5 import QtCore, QtGui, QtWidgets

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(800, 480)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Fixed, QtWidgets.QSizePolicy.Fixed)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(MainWindow.sizePolicy().hasHeightForWidth())
        MainWindow.setSizePolicy(sizePolicy)
        MainWindow.setStyleSheet("#pageManual QPushButton, #pageManual QToolButton {\n"
"    border: 2px solid black;\n"
"    border-radius: 20;\n"
"}\n"
"\n"
"#btnMan10 {\n"
"    background-color: transparent;\n"
"    background: none;\n"
"    background-repeat: none;\n"
"}")
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.verticalLayoutWidget = QtWidgets.QWidget(self.centralwidget)
        self.verticalLayoutWidget.setGeometry(QtCore.QRect(10, 10, 781, 461))
        self.verticalLayoutWidget.setObjectName("verticalLayoutWidget")
        self.verticalLayout = QtWidgets.QVBoxLayout(self.verticalLayoutWidget)
        self.verticalLayout.setContentsMargins(0, 0, 0, 0)
        self.verticalLayout.setObjectName("verticalLayout")
        self.menuFrame = QtWidgets.QFrame(self.verticalLayoutWidget)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Preferred, QtWidgets.QSizePolicy.Minimum)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.menuFrame.sizePolicy().hasHeightForWidth())
        self.menuFrame.setSizePolicy(sizePolicy)
        self.menuFrame.setMinimumSize(QtCore.QSize(0, 100))
        self.menuFrame.setStyleSheet("QToolButton {\n"
"    font-size: 20px;\n"
"}\n"
"\n"
"QFrame {\n"
"    background-color: rgb(255, 255, 255);\n"
"}\n"
"")
        self.menuFrame.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.menuFrame.setFrameShadow(QtWidgets.QFrame.Raised)
        self.menuFrame.setObjectName("menuFrame")
        self.horizontalLayoutWidget = QtWidgets.QWidget(self.menuFrame)
        self.horizontalLayoutWidget.setGeometry(QtCore.QRect(0, 0, 781, 101))
        self.horizontalLayoutWidget.setObjectName("horizontalLayoutWidget")
        self.horizontalLayout = QtWidgets.QHBoxLayout(self.horizontalLayoutWidget)
        self.horizontalLayout.setContentsMargins(0, 0, 0, 0)
        self.horizontalLayout.setObjectName("horizontalLayout")
        self.btnManual = QtWidgets.QToolButton(self.horizontalLayoutWidget)
        self.btnManual.setObjectName("btnManual")
        self.horizontalLayout.addWidget(self.btnManual)
        self.btnAuto = QtWidgets.QToolButton(self.horizontalLayoutWidget)
        self.btnAuto.setObjectName("btnAuto")
        self.horizontalLayout.addWidget(self.btnAuto)
        self.btnDiag = QtWidgets.QToolButton(self.horizontalLayoutWidget)
        self.btnDiag.setObjectName("btnDiag")
        self.horizontalLayout.addWidget(self.btnDiag)
        self.verticalLayout.addWidget(self.menuFrame)
        spacerItem = QtWidgets.QSpacerItem(20, 10, QtWidgets.QSizePolicy.Minimum, QtWidgets.QSizePolicy.Minimum)
        self.verticalLayout.addItem(spacerItem)
        self.stackedWidget = QtWidgets.QStackedWidget(self.verticalLayoutWidget)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Preferred, QtWidgets.QSizePolicy.Expanding)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.stackedWidget.sizePolicy().hasHeightForWidth())
        self.stackedWidget.setSizePolicy(sizePolicy)
        self.stackedWidget.setFrameShape(QtWidgets.QFrame.NoFrame)
        self.stackedWidget.setObjectName("stackedWidget")
        self.pageManual = QtWidgets.QWidget()
        self.pageManual.setObjectName("pageManual")
        self.horizontalLayoutWidget_2 = QtWidgets.QWidget(self.pageManual)
        self.horizontalLayoutWidget_2.setGeometry(QtCore.QRect(0, 0, 781, 341))
        self.horizontalLayoutWidget_2.setObjectName("horizontalLayoutWidget_2")
        self.horizontalLayout_2 = QtWidgets.QHBoxLayout(self.horizontalLayoutWidget_2)
        self.horizontalLayout_2.setSizeConstraint(QtWidgets.QLayout.SetDefaultConstraint)
        self.horizontalLayout_2.setContentsMargins(0, 0, 0, 0)
        self.horizontalLayout_2.setObjectName("horizontalLayout_2")
        spacerItem1 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_2.addItem(spacerItem1)
        self.verticalLayout_2 = QtWidgets.QVBoxLayout()
        self.verticalLayout_2.setObjectName("verticalLayout_2")
        self.btnMan1 = QtWidgets.QPushButton(self.horizontalLayoutWidget_2)
        self.btnMan1.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan1.setText("")
        self.btnMan1.setFlat(False)
        self.btnMan1.setObjectName("btnMan1")
        self.verticalLayout_2.addWidget(self.btnMan1)
        spacerItem2 = QtWidgets.QSpacerItem(20, 40, QtWidgets.QSizePolicy.Minimum, QtWidgets.QSizePolicy.Expanding)
        self.verticalLayout_2.addItem(spacerItem2)
        self.btnMan2 = QtWidgets.QPushButton(self.horizontalLayoutWidget_2)
        self.btnMan2.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan2.setText("")
        self.btnMan2.setFlat(False)
        self.btnMan2.setObjectName("btnMan2")
        self.verticalLayout_2.addWidget(self.btnMan2)
        self.horizontalLayout_2.addLayout(self.verticalLayout_2)
        spacerItem3 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_2.addItem(spacerItem3)
        self.verticalLayout_4 = QtWidgets.QVBoxLayout()
        self.verticalLayout_4.setObjectName("verticalLayout_4")
        self.btnMan3 = QtWidgets.QToolButton(self.horizontalLayoutWidget_2)
        self.btnMan3.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan3.setText("")
        icon = QtGui.QIcon()
        icon.addPixmap(QtGui.QPixmap(":/cold.png"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.btnMan3.setIcon(icon)
        self.btnMan3.setIconSize(QtCore.QSize(90, 90))
        self.btnMan3.setObjectName("btnMan3")
        self.verticalLayout_4.addWidget(self.btnMan3)
        self.horizontalLayout_2.addLayout(self.verticalLayout_4)
        spacerItem4 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_2.addItem(spacerItem4)
        self.verticalLayout_5 = QtWidgets.QVBoxLayout()
        self.verticalLayout_5.setObjectName("verticalLayout_5")
        self.btnMan4 = QtWidgets.QPushButton(self.horizontalLayoutWidget_2)
        self.btnMan4.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan4.setText("")
        self.btnMan4.setFlat(False)
        self.btnMan4.setObjectName("btnMan4")
        self.verticalLayout_5.addWidget(self.btnMan4)
        spacerItem5 = QtWidgets.QSpacerItem(20, 40, QtWidgets.QSizePolicy.Minimum, QtWidgets.QSizePolicy.Expanding)
        self.verticalLayout_5.addItem(spacerItem5)
        self.btnMan5 = QtWidgets.QPushButton(self.horizontalLayoutWidget_2)
        self.btnMan5.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan5.setText("")
        self.btnMan5.setFlat(False)
        self.btnMan5.setObjectName("btnMan5")
        self.verticalLayout_5.addWidget(self.btnMan5)
        self.horizontalLayout_2.addLayout(self.verticalLayout_5)
        spacerItem6 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_2.addItem(spacerItem6)
        self.stackedWidget.addWidget(self.pageManual)
        self.pageAuto = QtWidgets.QWidget()
        self.pageAuto.setObjectName("pageAuto")
        self.stackedWidget.addWidget(self.pageAuto)
        self.pageDiag = QtWidgets.QWidget()
        self.pageDiag.setObjectName("pageDiag")
        self.stackedWidget.addWidget(self.pageDiag)
        self.verticalLayout.addWidget(self.stackedWidget)
        MainWindow.setCentralWidget(self.centralwidget)

        self.retranslateUi(MainWindow)
        self.stackedWidget.setCurrentIndex(0)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "Yamori"))
        self.btnManual.setText(_translate("MainWindow", "Manual"))
        self.btnAuto.setText(_translate("MainWindow", "Automat"))
        self.btnDiag.setText(_translate("MainWindow", "Diagnostyka"))

import icons_rc
