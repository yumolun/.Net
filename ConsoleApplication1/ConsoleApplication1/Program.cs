using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public delegate void MakeGreatingEventHandler(string name);

        class DelegateManager
        {
            public event MakeGreatingEventHandler eh;

            public void MakeGreating(string name)
            {
                if (eh != null)
                    eh(name);
            }
        }


        static void EnglighGreating(string name)
        {
            Console.WriteLine("Good morning, " + name);
            Console.WriteLine();
        }

        static void ChineseGreating(string name)
        {
            Console.WriteLine("早上好，" + name);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            DelegateManager dm = new DelegateManager();
            dm.eh += EnglighGreating;
            dm.eh += ChineseGreating;

            dm.MakeGreating("Molun");
            Console.Read();
        }
    }
}
