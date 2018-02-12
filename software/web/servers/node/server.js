let express = require('express')
app = express()
let zmq = require('zmq');
let requester = zmq.socket('req');
let uuid = require('node-uuid');

requester.connect('tcp://127.0.0.1:5559');

// requester.on('message', function(msg) {
//   console.log('got reply', replyNbr, msg.toString());
//   replyNbr += 1;
// });

// setInterval(function() {
//   requester.send("Hello");
// }, 1000);

responses = {};

requester.on('message', function(data) {
  data = JSON.parse(data);
  let msgId = data.id;
  let res = responses[msgId];
  res.send(data.message);
  delete responses[msgId];
});

app.get("/", function(req, res) {
  let msgId = uuid.v4();
  let data = { id: msgId, message: 'nodejs' };
  responses[msgId] = res;
  str = JSON.stringify(data)
  console.log('Sending: ' + str)
  requester.send(str);
});

app.listen(3000, function() {
    console.log("Server started.");
});