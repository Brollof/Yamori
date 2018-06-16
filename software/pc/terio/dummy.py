import logging

class DigitalOutputDevice():
    def __init__(self, pin, active_high=True, initial_value=False):
        self.pin = pin
        self.value = initial_value
        self.log = logging.getLogger('DUMMY IO')

    def toggle(self):
        self.log.debug('Pin {} toggle'.format(self.pin))
        self.value = not self.value

    def on(self):
        self.log.debug('Pin {} on'.format(self.pin))
        self.value = True

    def off(self):
        self.log.debug('Pin {} off'.format(self.pin))
        self.value = False