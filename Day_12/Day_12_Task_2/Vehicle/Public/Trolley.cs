using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_2.Vehicle.Public
{
    public class Trolley : Vehicle, IPublicTransportable
    {
        public Trolley() : base()
        {
            Console.Write("Enter passengers max amount  : ");
            PassengersMaxAmount = Convert.ToInt32(Console.ReadLine());
        }

        public int PassengersMaxAmount { get; set; }

        public override void PrintData()
        {
            Console.WriteLine($"Trolley`s name : {Name}, production year : {ProductionYear}, max passengers : {PassengersMaxAmount}");
        }
    }
}
