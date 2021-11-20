using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_2.Vehicle.Public
{
    public class Bus : Vehicle, IPublicTransportable
    {
        public Bus() : base()
        {
            Console.Write("Enter passengers max amount  : ");
            PassengersMaxAmount = Convert.ToInt32(Console.ReadLine());
        }

        public int PassengersMaxAmount { get; set; }

        public override void PrintData()
        {
            Console.WriteLine($"Bus`s name : {Name}, production year : {ProductionYear}, max passengers : {PassengersMaxAmount}");
        }
    }
}
