using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mlem
{
    class Link
    {
        // min - czerwona 0.5h
        // max - off wszystko 1h, dalej normalnie
        private string server;
        private int port;
        private TcpClient conn;
        private NetworkStream stream;
        private bool connected = false;

        public bool IsConnected
        {
            get { return connected; }
            set { connected = value; }
        }

        public Link(string server, int port)
        {
            this.server = server;
            this.port = port;
        }

        public void Close()
        {
            stream.Close();
            conn.Close();
            connected = false;
        }

        public void Send(string message)
        {
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", message);
        }

        public void Send(Byte[] data)
        {
            throw new NotImplementedException();
        }

        public void Receive()
        {
            Byte[] rawRx = new Byte[256];
            string data = null;

            int bytes = stream.Read(rawRx, 0, rawRx.Length);
            data = System.Text.Encoding.ASCII.GetString(rawRx, 0, bytes);
            Console.WriteLine("Received: {0}", data);
        }

        public bool Connect()
        {
            try
            {
                conn = new TcpClient(server, port);
                stream = conn.GetStream();
                return (connected = true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            return false;
        }
    }
}
