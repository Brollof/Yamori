import re

def addStyle(widget, style):
    if style[-1] != ';':
        style += ';'
    widget.setStyleSheet(widget.styleSheet() + style)

def toRed(widget):
    addStyle(widget, 'background-color: red')

def toGreen(widget):
    addStyle(widget, 'background-color: green')

def setAlpha(widget, percent):
    """ Sets alpha in rgba property """
    style = widget.styleSheet()
    oldColor = re.search(r'rgba.+;', style).group(0)
    newColor = re.sub(r'\d+%', str(percent) + "%", oldColor)
    style = style.replace(oldColor, newColor)
    widget.setStyleSheet(style)