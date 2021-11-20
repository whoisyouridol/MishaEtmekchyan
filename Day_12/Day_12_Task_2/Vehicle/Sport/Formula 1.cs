using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_2.Vehicle.Sport
{
    class Formula_1 : Vehicle, ISportTransportable
    {
      
        public double MaxSpeed { get; set; }


        public Formula_1() : base()
        {
            Console.Write("Enter max speed : ");
            MaxSpeed = Convert.ToInt32(Console.ReadLine());
        }

        public override void PrintData()
        {
            Console.WriteLine($"SportCar`s name : {Name}, production year : {ProductionYear}, max speed : {MaxSpeed}");
        }
    }
}
