using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_2.Vehicle.Standart
{
    interface IStandartTransporable
    {
        public double EngineVolume { get; set; }

        public double Price { get; set; }
        public void PrintPriceInDollars();
    }
}
