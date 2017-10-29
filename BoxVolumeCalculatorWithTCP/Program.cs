using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxVolumeCalculatorWithTCP
{
    class Program
    {
        private const int PORT = 9999;

        static void Main(string[] args)
        {
            ServerClass server = new ServerClass(PORT);
            server.Start();

            Console.ReadLine();
        }
    }
}
