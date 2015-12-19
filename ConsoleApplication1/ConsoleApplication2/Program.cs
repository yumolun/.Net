using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Heater h = new Heater();
            Monitor m = new Monitor();
            Alarm a = new Alarm();

            h.boiledEvent += m.Display;
            h.boiledEvent += a.Alert;

            h.BoilWater();

            Console.Read();
        }
    }
}
