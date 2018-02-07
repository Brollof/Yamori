def convertBool(boolVal, ifTrue, ifFalse):
    if type(boolVal) is not bool:
        raise TypeError
    return ifTrue if boolVal else ifFalse

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