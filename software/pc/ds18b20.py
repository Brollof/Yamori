import os
import glob
import time
import logging

class DS18B20():
    def __init__(self):
        self.log = logging.getLogger('DS18B20')
        if os.name in ["posix", "unix"]: # rpi
            baseDir = '/sys/bus/w1/devices/'
        else:
            baseDir = './sys/bus/w1/devices/' # sensors simulation

        deviceFolders = glob.glob(baseDir + '28*')
        deviceFiles = [folder + '/w1_slave' for folder in deviceFolders]
        names = [folder[-15:] for folder in deviceFolders]
        self.devices = dict(zip(names, deviceFiles))

    def __readTempsRaw(self):
        ret = {}
        for name, dev in self.devices.items():
            try:
                f = open(dev, 'r')
                ret[name] = f.readlines()
                f.close()
            except Exception as e:
                self.log.error(e)
        return ret

    def readTemps(self):
        temps = {}
        rawData = self.__readTempsRaw()
        for name, temp in rawData.items():
            while rawData[name][0].strip()[-3:] != 'YES':
                time.sleep(0.2)
                rawData = self.__readTempsRaw()

            equalsPos = rawData[name][1].find('t=')
            if equalsPos != -1:
                tempStr = rawData[name][1][equalsPos + 2:]
                temps[name] = float(tempStr) / 1000.0
        return temps

def printPeriodic(ds):
    for i in range(3):
        temps = ds.readTemps()
        for n, t in temps.items():
            print('name: %s, temp: %3.1f*C' % (n, t))
        print('------------------------------------------')
        time.sleep(1)

def main():
    ds = DS18B20()
    print(ds.readTemps())
    printPeriodic(ds)

if __name__ == '__main__':
    main()