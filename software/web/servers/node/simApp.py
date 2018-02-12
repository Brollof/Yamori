# import zmq
# from time import sleep

# context = zmq.Context()
# socket = context.socket(zmq.SUB)
# socket.connect("tcp://127.0.0.1:6701")

# socket.setsockopt(zmq.SUBSCRIBE, b'')

# while True:
#     multipart = socket.recv_multipart()
#     address = multipart[0]
#     print(multipart)
#     sleep(0.5)

# socket.close()
# context.term()

#######################################################################
#######################################################################
#######################################################################

# import socket
# import sys
# import time
# import datetime
# import sys

# sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# server_address = ('localhost', 4545)
# print(sys.stderr, 'connecting to %s port %s' % server_address)
# sock.connect(server_address)

# sock.sendall(b"start")

# while True:
#     veri="deneme"
#     veriler = ("%s,%s"%(veri,str(datetime.datetime.now())))
 
#     print(veriler)
#     sock.sendall(bytearray(veriler, 'utf8'))

#     time.sleep(5)


#########################################################################
#########################################################################
#########################################################################

import zmq
import signal
import json
from time import sleep

interrupted = False

def signal_handler(signum, frame):
  global interrupted
  interrupted = True

context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://127.0.0.1:5559")

signal.signal(signal.SIGINT, signal_handler)

while True:
  try:
    message = socket.recv(zmq.NOBLOCK)
    data = json.loads(message)
    msgId = data['id']
    print(data)
    resp = {'id': msgId, 'message': 'O KURWA TO DZIALA'}
    socket.send(json.dumps(resp).encode('utf8'))
    sleep(0.5)
  except zmq.ZMQError:
    pass

  if interrupted:
    print("Interrupt received, killing server...")
    break

socket.close()
context.term()