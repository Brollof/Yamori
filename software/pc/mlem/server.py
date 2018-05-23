# Echo server program
import socket
from time import sleep
import json

def main():
    HOST = ''
    PORT = 50007

    while True:
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.bind((HOST, PORT))
            print('Binded')
            s.listen(1)
            conn, addr = s.accept()
            print('Accepted')
            with conn:
                print('Connected by', addr)
                while True:
                    data = conn.recv(1024)
                    if not data:
                        print('Disconnected...')
                        break
                    # else:
                        # conn.sendall(data)

                    if data.decode('ascii') == 'read command':
                        conn.sendall(b'sending current config')
                    else:
                        data = json.loads(data)
                        print(data)
                        # print("Heater: ")
                        # print(data['Heater'])
                        for i in data['Events']['Lamps']:
                            print(i)
                    sleep(0.5)
  

if __name__ == '__main__':
    main()