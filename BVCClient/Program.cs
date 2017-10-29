using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVCClient
{
    class Program
    {
        private const int PORT = 9999;
        static void Main(string[] args)
        {
            ClientClass client = new ClientClass(PORT);
            client.Start();

            Console.ReadLine();
        }
    }
}
