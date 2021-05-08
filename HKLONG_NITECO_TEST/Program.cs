using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKLONG_NITECO_TEST
{
    class Program
    {
        static void Main(string[] args)
        {

            TrafficSimulation trafficSimulation = new TrafficSimulation();

            trafficSimulation.Run();

            Console.ReadLine();
        }
    }
}
