import sys
import os
import subprocess
import time
from datetime import datetime

LOG_FILE = 'cpu_temp.log'
TIME_LOG_PERIOD = 60 # seconds
DIR_PATH = os.path.dirname(os.path.realpath(__file__))
FULL_LOG_PATH = os.path.join(DIR_PATH, LOG_FILE)

verbose = False

def get_temp():
    a = subprocess.run('vcgencmd measure_temp', stdout=subprocess.PIPE, shell=True, check=True, universal_newlines=True)
    return a.stdout.strip()

def get_time():
    return datetime.now().strftime('%Y-%m-%d %H:%M:%S')

def write_data():
    with open(FULL_LOG_PATH, 'a+') as f:
        data = '{}: {}\n'.format(get_time(), get_temp())
        if verbose:
            print('Writing: %s' % data, end='')
        f.write(data)

if __name__ == '__main__':
    try:
        verbose = sys.argv[1]
    except Exception:
        pass

    if verbose:
        print('CPU temperature logger. Logging to file: %s' %FULL_LOG_PATH)
        print('Running in verbose mode')

    while True:
        write_data()
        time.sleep(TIME_LOG_PERIOD)
