import json

def convertBool(boolVal, ifTrue, ifFalse):
    if type(boolVal) is not bool:
        print(type(boolVal))
        raise TypeError
    return ifTrue if boolVal else ifFalse

def readJsonFile(filename, logger=None):
    try:
        with open(filename, 'r') as f:
            return json.load(f)
    except Exception as e:
        if logger:
            logger.error("File reading failed!")
            logger.error(e)
        else:
            print("File reading failed!")
            print(e)
        return None

def writeJsonFile(filename, data, logger=None):
    try:
        with open(filename, 'w') as f:
            json.dump(data, f, indent=2)
    except Exception as e:
        if logger:
            logger.error("File writing failed!")
            logger.error(e)
        else:
            print("File writing failed!")
            print(e)

# test functions
def main():
    a = convertBool(True, 'ON', 'OFF')
    print('{}'.format('PASS' if a == 'ON' else 'FAIL'))

    a = convertBool(False, 'ON', 'OFF')
    print('{}'.format('PASS' if a == 'OFF' else 'FAIL'))

    try:
        a = convertBool('asd', 'ON', 'OFF')
    except TypeError:
        print('PASS')
    else:
        print('FAIL')

if __name__ == '__main__':
    main()