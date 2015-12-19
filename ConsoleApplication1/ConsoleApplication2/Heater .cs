using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Heater
    {
        public readonly string type = "HeHe";
        public readonly string area = "France";

        public delegate void BoiledEventHandler(Object sender, BoiledEventArgs e);

        public event BoiledEventHandler boiledEvent;

        public class BoiledEventArgs : EventArgs
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }

        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if(boiledEvent != null)
            {
                boiledEvent(this, e);
            }
        }

        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 95)
                    OnBoiled(new BoiledEventArgs(i));
            }
        }
    }
}
