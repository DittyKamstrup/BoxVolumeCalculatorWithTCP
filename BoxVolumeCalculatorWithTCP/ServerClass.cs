using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BoxVolumeCalculatorWithTCP
{
    public class ServerClass
    {
        private readonly int PORT;

        public ServerClass(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            TcpListener listener = TcpListener.Create(PORT);
            listener.Start();

            while (true)
            {
                using (TcpClient client = listener.AcceptTcpClient())
                {
                    Task.Run( () => DoClient(client));         //Task gør, at det kører async, altså at flere clienter kan køre parallelt med hinanden
                }
            }
        }

        public void DoClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                //read
                string message = reader.ReadLine();

                //process
                string[] stringArray = message.Split(' ');

                // evt fejl behandling fx. strings.Length == 4 - Fra Peter

                double value1 = double.Parse(stringArray[1]);
                double value2 = double.Parse(stringArray[2]);
                double value3 = double.Parse(stringArray[3]);

                //write
                if (stringArray[0].ToLower() == "volume")
                {
                    writer.WriteLine(value1 * value2 * value3);
                    writer.Flush();
                }

                if (stringArray[0].ToLower() == "side")
                {
                    writer.WriteLine(value1 / (value2 * value3));
                    writer.Flush();
                }

                client.Close();

            }
        }

    }
}
