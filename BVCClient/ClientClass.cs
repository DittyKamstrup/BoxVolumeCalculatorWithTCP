using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BVCClient
{
    public class ClientClass
    {
        private readonly int PORT;

        public ClientClass(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            string clientMessage = "volume 2 2 2";
            SendRequest(clientMessage);

            string clientMessage2 = "side 10 2 2";
            SendRequest(clientMessage2);
        }

        private void SendRequest(string clientMessage)
        {
            using (TcpClient client = new TcpClient("localhost", PORT))
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(clientMessage);
                writer.Flush();

                string resultatString = reader.ReadLine();
                Console.WriteLine("Resultatet af " + clientMessage + " er: " + resultatString);
            }
        }

    }
}
