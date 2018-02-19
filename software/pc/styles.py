import re

def addStyle(widget, style):
    if style[-1] != ';':
        style += ';'
    widget.setStyleSheet(widget.styleSheet() + style)

def setAlpha(widget, percent):
    """ Sets alpha in rgba property """
    style = widget.styleSheet()
    oldColor = re.search(r'rgba.+;', style).group(0)
    newColor = re.sub(r'\d+%', str(percent) + "%", oldColor)
    style = style.replace(oldColor, newColor)
    widget.setStyleSheet(style)

def removeStyle(widget, prop):
    style = widget.styleSheet()
    style = style.replace(prop+';', '')
    widget.setStyleSheet(style)