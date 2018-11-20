from evdev import InputDevice, categorize, ecodes
import datetime

def from_timestamp(timestamp):
    return datetime.datetime.fromtimestamp(timestamp).strftime('%Y-%m-%d %H:%M:%S')

if __name__ == '__main__':
    dev = InputDevice('/dev/input/event0')
    with open('/home/pi/tools/lcd.log', 'a+') as f:
        for event in dev.read_loop():
            if event.type == ecodes.EV_ABS:
                cat = categorize(event)
                data = str(cat) + '\n' + str(cat.event) + '\n'
                f.write(data)
