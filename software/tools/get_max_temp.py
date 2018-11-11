import os
import re
import argparse

DEFAULT_LOG_FILE = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'cpu_temp.log')
CPU_TEMP_REGEX = r'temp=(\d\d\.\d)'

if __name__ == '__main__':
    parser = argparse.ArgumentParser()
    parser.add_argument('-f', '--file', help='file to read max temperature from')
    args = parser.parse_args()

    if args.file:
        logfile = args.file
    else:
        logfile = DEFAULT_LOG_FILE

    if os.path.isfile(logfile):
        try: 
            with open(logfile, 'r') as f:
                line = f.readline()
                max_temp = {'val': 0, 'raw': 'Empty file?'}
                while line:
                    line = f.readline()
                    res = re.search(CPU_TEMP_REGEX, line)
                    if res:
                        temp = float(res.group(1))
                        if temp > max_temp['val']:
                            max_temp['val'] = temp
                            max_temp['raw'] = line.strip()
                print(max_temp['raw'])
        except IOError as e:
            print("Unable to open file")
    else:
        print("File \"%s\" doesn't exist!" %logfile)