import logging
import sys

sys.path.append("..")
from config import config

if config.getPlatform() == 'rpi':
    from gpiozero import DigitalOutputDevice
else:
    from terio.dummy import DigitalOutputDevice

log = logging.getLogger("DEVICE")

SLOT_TO_PIN = {
    1: 0,
    2: 1,
    3: 2,
    4: 3,
    5: 5,
    6: 6,
    7: 7,
    8: 8
}

MAX_DEVICE_NUM = len(SLOT_TO_PIN)

Devices = {}

class Device():
    def __init__(self, name, slot, dtype, color=None):
        self.name = name
        self.slot = slot
        self.color = color
        self.dtype = dtype
        self.pin = getPin(slot)
        self.io = DigitalOutputDevice(self.pin, active_high=False, initial_value=False)
        log.info('Device with slot {} created'.format(self.slot))

    def __str__(self):
        return "Slot:{}, Pin:{}, State:{}, Name:{}, Color:{}".format(self.slot, self.pin, self.io.value, self.name, self.color)

def getPin(slot):
    return SLOT_TO_PIN[slot]

def add(dev):
    Devices[dev.slot] = dev

def clear():
    Devices.clear()

def getDevice(slot):
    try:
        return Devices[slot]
    except Exception:
        log.warning('Device with slot {} number doesnt exist!'.format(slot))
        return None

def printInfo(name=None):
    if name:
        slot = nameToSlot(name)
        print(Devices[slot])
    else:
        print("--------------- DEVICES ---------------")
        for slot in Devices:
            print(Devices[slot])
        print("---------------------------------------")

def nameToSlot(name):
    for slot, dev in Devices.items():
        if dev.name == name:
            return slot

def setState(name, action):
    action = action.lower()
    slot = nameToSlot(name)
    if action == 'on':
        Devices[slot].io.on()
    elif action == 'off':
        Devices[slot].io.off()
    elif action == 'toggle':
        Devices[slot].io.toggle()
    else:
        raise NameError

def getState(name):
    slot = nameToSlot(name)
    return Devices[slot].io.value;

def getNames():
    return [Devices[slot].name for slot in Devices]

if __name__ == '__main__':
    create('garbage', 1)
    create('blue', 1)
    create('red', 2)
    create('green', 3, (0, 255, 0))
    printInfo()
    setState('blue', 'on')

    print(getNames())