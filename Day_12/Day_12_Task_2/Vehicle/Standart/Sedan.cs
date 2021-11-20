using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_2.Vehicle.Standart
{
    class Sedan : Vehicle, IStandartTransporable
    {
        public double EngineVolume { get; set; }
        public double Price { get; set; }

        public Sedan() : base()
        {
            Console.Write("Enter engine volume : ");
            EngineVolume = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter car`s price : ");
            Price = Convert.ToDouble(Console.ReadLine());
        }
        public override void PrintData()
        {
            Console.WriteLine($"Sedan`s name : {Name}, production year : {ProductionYear}, engine volume : {EngineVolume}, price : {Price}");
        }

        public void PrintPriceInDollars()
        {
            Console.WriteLine($"Car`s price : ${Price}");
        }
    }
}