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
        MainWindow.setWindowModality(QtCore.Qt.NonModal)
        MainWindow.resize(800, 480)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Fixed, QtWidgets.QSizePolicy.Fixed)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(MainWindow.sizePolicy().hasHeightForWidth())
        MainWindow.setSizePolicy(sizePolicy)
        MainWindow.setMinimumSize(QtCore.QSize(800, 480))
        MainWindow.setMaximumSize(QtCore.QSize(800, 480))
        MainWindow.setAutoFillBackground(False)
        MainWindow.setStyleSheet("#menuFrame {\n"
"    border: 4px solid #ffe0b2;\n"
"}\n"
"\n"
"#centralwidget {\n"
"    background-color: white;\n"
"}\n"
"\n"
"#pageManual QPushButton, #pageManual QToolButton {\n"
"    border: 2px solid black;\n"
"    border-radius: 20;\n"
"}\n"
"\n"
"#menuFrame QToolButton {\n"
"    border: none;\n"
"    qproperty-iconSize: 60px;\n"
"    qproperty-toolButtonStyle: ToolButtonTextUnderIcon;\n"
"}\n"
"\n"
"#pageDiag QGroupBox {\n"
"    font-size: 30px;\n"
"    color: #0099CC;\n"
"}\n"
"\n"
"#pageDiag QGroupBox QLabel{\n"
"    font-size: 20px;\n"
"    color: #00C851;\n"
"}\n"
"\n"
"#mainView > QWidget {\n"
"    background-color: white;\n"
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
        self.menuFrame.setMinimumSize(QtCore.QSize(0, 110))
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
        self.horizontalLayoutWidget.setGeometry(QtCore.QRect(0, 0, 781, 111))
        self.horizontalLayoutWidget.setObjectName("horizontalLayoutWidget")
        self.horizontalLayout = QtWidgets.QHBoxLayout(self.horizontalLayoutWidget)
        self.horizontalLayout.setContentsMargins(0, 0, 0, 0)
        self.horizontalLayout.setObjectName("horizontalLayout")
        self.btnManual = QtWidgets.QToolButton(self.horizontalLayoutWidget)
        self.btnManual.setAutoFillBackground(False)
        icon = QtGui.QIcon()
        icon.addPixmap(QtGui.QPixmap(":/i_manual.png"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.btnManual.setIcon(icon)
        self.btnManual.setIconSize(QtCore.QSize(60, 60))
        self.btnManual.setCheckable(False)
        self.btnManual.setPopupMode(QtWidgets.QToolButton.DelayedPopup)
        self.btnManual.setToolButtonStyle(QtCore.Qt.ToolButtonTextUnderIcon)
        self.btnManual.setAutoRaise(False)
        self.btnManual.setArrowType(QtCore.Qt.NoArrow)
        self.btnManual.setObjectName("btnManual")
        self.horizontalLayout.addWidget(self.btnManual)
        self.btnAuto = QtWidgets.QToolButton(self.horizontalLayoutWidget)
        icon1 = QtGui.QIcon()
        icon1.addPixmap(QtGui.QPixmap(":/i_auto.png"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.btnAuto.setIcon(icon1)
        self.btnAuto.setObjectName("btnAuto")
        self.horizontalLayout.addWidget(self.btnAuto)
        self.btnDiag = QtWidgets.QToolButton(self.horizontalLayoutWidget)
        icon2 = QtGui.QIcon()
        icon2.addPixmap(QtGui.QPixmap(":/i_diag.png"), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.btnDiag.setIcon(icon2)
        self.btnDiag.setObjectName("btnDiag")
        self.horizontalLayout.addWidget(self.btnDiag)
        self.verticalLayout.addWidget(self.menuFrame)
        self.mainView = QtWidgets.QStackedWidget(self.verticalLayoutWidget)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Preferred, QtWidgets.QSizePolicy.Expanding)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.mainView.sizePolicy().hasHeightForWidth())
        self.mainView.setSizePolicy(sizePolicy)
        self.mainView.setStyleSheet("")
        self.mainView.setFrameShape(QtWidgets.QFrame.NoFrame)
        self.mainView.setObjectName("mainView")
        self.pageManual = QtWidgets.QWidget()
        self.pageManual.setObjectName("pageManual")
        self.horizontalLayoutWidget_2 = QtWidgets.QWidget(self.pageManual)
        self.horizontalLayoutWidget_2.setGeometry(QtCore.QRect(0, 0, 781, 341))
        self.horizontalLayoutWidget_2.setObjectName("horizontalLayoutWidget_2")
        self.horizontalLayout_2 = QtWidgets.QHBoxLayout(self.horizontalLayoutWidget_2)
        self.horizontalLayout_2.setSizeConstraint(QtWidgets.QLayout.SetDefaultConstraint)
        self.horizontalLayout_2.setContentsMargins(0, 0, 0, 0)
        self.horizontalLayout_2.setObjectName("horizontalLayout_2")
        spacerItem = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_2.addItem(spacerItem)
        self.verticalLayout_2 = QtWidgets.QVBoxLayout()
        self.verticalLayout_2.setSizeConstraint(QtWidgets.QLayout.SetDefaultConstraint)
        self.verticalLayout_2.setObjectName("verticalLayout_2")
        self.btnMan1 = QtWidgets.QPushButton(self.horizontalLayoutWidget_2)
        self.btnMan1.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan1.setText("")
        self.btnMan1.setFlat(False)
        self.btnMan1.setObjectName("btnMan1")
        self.verticalLayout_2.addWidget(self.btnMan1)
        spacerItem1 = QtWidgets.QSpacerItem(20, 40, QtWidgets.QSizePolicy.Minimum, QtWidgets.QSizePolicy.Expanding)
        self.verticalLayout_2.addItem(spacerItem1)
        self.btnMan2 = QtWidgets.QPushButton(self.horizontalLayoutWidget_2)
        self.btnMan2.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan2.setText("")
        self.btnMan2.setFlat(False)
        self.btnMan2.setObjectName("btnMan2")
        self.verticalLayout_2.addWidget(self.btnMan2)
        self.horizontalLayout_2.addLayout(self.verticalLayout_2)
        spacerItem2 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_2.addItem(spacerItem2)
        self.verticalLayout_4 = QtWidgets.QVBoxLayout()
        self.verticalLayout_4.setObjectName("verticalLayout_4")
        self.btnMan3 = QtWidgets.QToolButton(self.horizontalLayoutWidget_2)
        self.btnMan3.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan3.setText("")
        self.btnMan3.setIconSize(QtCore.QSize(90, 90))
        self.btnMan3.setObjectName("btnMan3")
        self.verticalLayout_4.addWidget(self.btnMan3)
        self.horizontalLayout_2.addLayout(self.verticalLayout_4)
        spacerItem3 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_2.addItem(spacerItem3)
        self.verticalLayout_5 = QtWidgets.QVBoxLayout()
        self.verticalLayout_5.setObjectName("verticalLayout_5")
        self.btnMan4 = QtWidgets.QPushButton(self.horizontalLayoutWidget_2)
        self.btnMan4.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan4.setText("")
        self.btnMan4.setFlat(False)
        self.btnMan4.setObjectName("btnMan4")
        self.verticalLayout_5.addWidget(self.btnMan4)
        spacerItem4 = QtWidgets.QSpacerItem(20, 40, QtWidgets.QSizePolicy.Minimum, QtWidgets.QSizePolicy.Expanding)
        self.verticalLayout_5.addItem(spacerItem4)
        self.btnMan5 = QtWidgets.QPushButton(self.horizontalLayoutWidget_2)
        self.btnMan5.setMinimumSize(QtCore.QSize(120, 120))
        self.btnMan5.setText("")
        self.btnMan5.setFlat(False)
        self.btnMan5.setObjectName("btnMan5")
        self.verticalLayout_5.addWidget(self.btnMan5)
        self.horizontalLayout_2.addLayout(self.verticalLayout_5)
        spacerItem5 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_2.addItem(spacerItem5)
        self.mainView.addWidget(self.pageManual)
        self.pageAuto = QtWidgets.QWidget()
        self.pageAuto.setObjectName("pageAuto")
        self.mainView.addWidget(self.pageAuto)
        self.pageDiag = QtWidgets.QWidget()
        self.pageDiag.setObjectName("pageDiag")
        self.groupBox = QtWidgets.QGroupBox(self.pageDiag)
        self.groupBox.setGeometry(QtCore.QRect(10, 10, 561, 151))
        self.groupBox.setObjectName("groupBox")
        self.horizontalLayout_3 = QtWidgets.QHBoxLayout(self.groupBox)
        self.horizontalLayout_3.setObjectName("horizontalLayout_3")
        self.formLayout_3 = QtWidgets.QFormLayout()
        self.formLayout_3.setObjectName("formLayout_3")
        self.label = QtWidgets.QLabel(self.groupBox)
        self.label.setObjectName("label")
        self.formLayout_3.setWidget(0, QtWidgets.QFormLayout.LabelRole, self.label)
        self.label_11 = QtWidgets.QLabel(self.groupBox)
        self.label_11.setObjectName("label_11")
        self.formLayout_3.setWidget(0, QtWidgets.QFormLayout.FieldRole, self.label_11)
        self.label_10 = QtWidgets.QLabel(self.groupBox)
        self.label_10.setObjectName("label_10")
        self.formLayout_3.setWidget(1, QtWidgets.QFormLayout.LabelRole, self.label_10)
        self.label_12 = QtWidgets.QLabel(self.groupBox)
        self.label_12.setObjectName("label_12")
        self.formLayout_3.setWidget(1, QtWidgets.QFormLayout.FieldRole, self.label_12)
        self.label_15 = QtWidgets.QLabel(self.groupBox)
        self.label_15.setObjectName("label_15")
        self.formLayout_3.setWidget(2, QtWidgets.QFormLayout.LabelRole, self.label_15)
        self.label_16 = QtWidgets.QLabel(self.groupBox)
        self.label_16.setObjectName("label_16")
        self.formLayout_3.setWidget(2, QtWidgets.QFormLayout.FieldRole, self.label_16)
        self.horizontalLayout_3.addLayout(self.formLayout_3)
        spacerItem6 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_3.addItem(spacerItem6)
        self.formLayout = QtWidgets.QFormLayout()
        self.formLayout.setObjectName("formLayout")
        self.label_3 = QtWidgets.QLabel(self.groupBox)
        self.label_3.setObjectName("label_3")
        self.formLayout.setWidget(0, QtWidgets.QFormLayout.LabelRole, self.label_3)
        self.label_4 = QtWidgets.QLabel(self.groupBox)
        self.label_4.setObjectName("label_4")
        self.formLayout.setWidget(0, QtWidgets.QFormLayout.FieldRole, self.label_4)
        self.label_2 = QtWidgets.QLabel(self.groupBox)
        self.label_2.setObjectName("label_2")
        self.formLayout.setWidget(1, QtWidgets.QFormLayout.LabelRole, self.label_2)
        self.label_5 = QtWidgets.QLabel(self.groupBox)
        self.label_5.setObjectName("label_5")
        self.formLayout.setWidget(1, QtWidgets.QFormLayout.FieldRole, self.label_5)
        self.horizontalLayout_3.addLayout(self.formLayout)
        spacerItem7 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_3.addItem(spacerItem7)
        self.formLayout_6 = QtWidgets.QFormLayout()
        self.formLayout_6.setObjectName("formLayout_6")
        self.label_18 = QtWidgets.QLabel(self.groupBox)
        self.label_18.setObjectName("label_18")
        self.formLayout_6.setWidget(0, QtWidgets.QFormLayout.LabelRole, self.label_18)
        self.label_20 = QtWidgets.QLabel(self.groupBox)
        self.label_20.setObjectName("label_20")
        self.formLayout_6.setWidget(0, QtWidgets.QFormLayout.FieldRole, self.label_20)
        self.label_21 = QtWidgets.QLabel(self.groupBox)
        self.label_21.setObjectName("label_21")
        self.formLayout_6.setWidget(1, QtWidgets.QFormLayout.LabelRole, self.label_21)
        self.label_22 = QtWidgets.QLabel(self.groupBox)
        self.label_22.setObjectName("label_22")
        self.formLayout_6.setWidget(1, QtWidgets.QFormLayout.FieldRole, self.label_22)
        self.horizontalLayout_3.addLayout(self.formLayout_6)
        self.groupBox_2 = QtWidgets.QGroupBox(self.pageDiag)
        self.groupBox_2.setGeometry(QtCore.QRect(10, 200, 561, 91))
        self.groupBox_2.setObjectName("groupBox_2")
        self.horizontalLayout_4 = QtWidgets.QHBoxLayout(self.groupBox_2)
        self.horizontalLayout_4.setObjectName("horizontalLayout_4")
        self.formLayout_4 = QtWidgets.QFormLayout()
        self.formLayout_4.setObjectName("formLayout_4")
        self.label_13 = QtWidgets.QLabel(self.groupBox_2)
        self.label_13.setObjectName("label_13")
        self.formLayout_4.setWidget(0, QtWidgets.QFormLayout.LabelRole, self.label_13)
        self.label_14 = QtWidgets.QLabel(self.groupBox_2)
        self.label_14.setObjectName("label_14")
        self.formLayout_4.setWidget(0, QtWidgets.QFormLayout.FieldRole, self.label_14)
        self.horizontalLayout_4.addLayout(self.formLayout_4)
        spacerItem8 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_4.addItem(spacerItem8)
        self.formLayout_5 = QtWidgets.QFormLayout()
        self.formLayout_5.setObjectName("formLayout_5")
        self.label_17 = QtWidgets.QLabel(self.groupBox_2)
        self.label_17.setObjectName("label_17")
        self.formLayout_5.setWidget(0, QtWidgets.QFormLayout.LabelRole, self.label_17)
        self.label_19 = QtWidgets.QLabel(self.groupBox_2)
        self.label_19.setObjectName("label_19")
        self.formLayout_5.setWidget(0, QtWidgets.QFormLayout.FieldRole, self.label_19)
        self.horizontalLayout_4.addLayout(self.formLayout_5)
        spacerItem9 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_4.addItem(spacerItem9)
        self.formLayout_7 = QtWidgets.QFormLayout()
        self.formLayout_7.setObjectName("formLayout_7")
        self.label_23 = QtWidgets.QLabel(self.groupBox_2)
        self.label_23.setObjectName("label_23")
        self.formLayout_7.setWidget(0, QtWidgets.QFormLayout.LabelRole, self.label_23)
        self.label_24 = QtWidgets.QLabel(self.groupBox_2)
        self.label_24.setObjectName("label_24")
        self.formLayout_7.setWidget(0, QtWidgets.QFormLayout.FieldRole, self.label_24)
        self.horizontalLayout_4.addLayout(self.formLayout_7)
        self.mainView.addWidget(self.pageDiag)
        self.verticalLayout.addWidget(self.mainView)
        MainWindow.setCentralWidget(self.centralwidget)

        self.retranslateUi(MainWindow)
        self.mainView.setCurrentIndex(0)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "Yamori"))
        self.btnManual.setText(_translate("MainWindow", "Manual"))
        self.btnAuto.setText(_translate("MainWindow", "Automat"))
        self.btnDiag.setText(_translate("MainWindow", "Status"))
        self.groupBox.setTitle(_translate("MainWindow", "Terrarium"))
        self.label.setText(_translate("MainWindow", "Temperatura 1: "))
        self.label_11.setText(_translate("MainWindow", "0 *C"))
        self.label_10.setText(_translate("MainWindow", "Temperatura 2:"))
        self.label_12.setText(_translate("MainWindow", "0 *C"))
        self.label_15.setText(_translate("MainWindow", "Wilgotność:"))
        self.label_16.setText(_translate("MainWindow", "0"))
        self.label_3.setText(_translate("MainWindow", "Średnia:"))
        self.label_4.setText(_translate("MainWindow", "0 *C"))
        self.label_2.setText(_translate("MainWindow", "Średnia:"))
        self.label_5.setText(_translate("MainWindow", "0 *C"))
        self.label_18.setText(_translate("MainWindow", "Maks.:"))
        self.label_20.setText(_translate("MainWindow", "0 *C"))
        self.label_21.setText(_translate("MainWindow", "Maks.:"))
        self.label_22.setText(_translate("MainWindow", "0 *C"))
        self.groupBox_2.setTitle(_translate("MainWindow", "Procesor"))
        self.label_13.setText(_translate("MainWindow", "Temperatura: "))
        self.label_14.setText(_translate("MainWindow", "0 *C"))
        self.label_17.setText(_translate("MainWindow", "Średnia:"))
        self.label_19.setText(_translate("MainWindow", "0 *C"))
        self.label_23.setText(_translate("MainWindow", "Maks.:"))
        self.label_24.setText(_translate("MainWindow", "0 *C"))

import icons_rc
