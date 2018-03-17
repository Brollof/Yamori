class DigitalOutputDevice():
    def __init__(self, pin, active_high=True, initial_value=False):
        self.pin = pin
        self.value = initial_value
        
    def toggle(self):
        self.value = not self.value

    def on(self):
        self.value = True

    def off(self):
        self.value = False