from flask import Flask
import socket

app = Flask(__name__)
clientsocket = None

@app.route("/")
def hello():
  clientsocket.send(b'hello')
  return "Hello, World!"

@app.route("/secret-page")
def secret():
  page = str()
  page += "<h1>Hi on my secret page!</h1>"
  page += "LUL"
  return page
  
if __name__ == "__main__":
  clientsocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
  clientsocket.connect(('localhost', 8089))
  app.run()