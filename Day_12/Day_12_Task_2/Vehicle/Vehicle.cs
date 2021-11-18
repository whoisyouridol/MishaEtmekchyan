using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_2.Vehicle
{
    public abstract class Vehicle
    {
        public string Name { get; private set; }
        public int ProductionYear { get; private set; }

        public Vehicle()
        {
            Console.Write("Enter name : ");
            Name = Console.ReadLine();
            Console.Write("Enter production year : ");
            ProductionYear = Convert.ToInt32(Console.ReadLine());
        }
        public abstract void PrintData();

    }
}