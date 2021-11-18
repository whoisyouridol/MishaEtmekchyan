using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_2.Vehicle.Military
{
    public class BTR : Vehicle, IMilitariable
    {
        public double ShotPerSecond { get; set; }

        public BTR() : base()
        {

            Console.Write("Enter shot`s amount per second : ");
            ShotPerSecond = Convert.ToInt32(Console.ReadLine());
        }

        public override void PrintData()
        {
            Console.WriteLine($"BTR`s name : {Name}, production year : {ProductionYear}, shots per second : {ShotPerSecond}");
        }

        public int CountShotsPerMinute() => (int)(ShotPerSecond * 60);
    }
}
