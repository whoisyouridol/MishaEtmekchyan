using Day_12_Task_2.Vehicle.Military;
using Day_12_Task_2.Vehicle.Public;
using Day_12_Task_2.Vehicle.Sport;
using Day_12_Task_2.Vehicle.Standart;
using System;

namespace Day_12_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, select one of the vehicle type : ");
            Console.WriteLine("Military : ");
            Console.WriteLine("1 - Tank");
            Console.WriteLine("2 - BTR");
            Console.WriteLine("__________________________________");
            Console.WriteLine("Public : ");
            Console.WriteLine("3 - Bus");
            Console.WriteLine("4 - Trolley");
            Console.WriteLine("__________________________________");
            Console.WriteLine("5 - Sedan");
            Console.WriteLine("__________________________________");
            Console.WriteLine("6 - Supercar");

            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:var tank = new Tank();
                    tank.PrintData();
                    break;
                case 2:
                    var btr = new BTR();
                    btr.PrintData();
                    break;
                case 3:
                    var bus = new Bus();
                    bus.PrintData();
                    break;
                case 4:
                    var trolley = new Trolley();
                    trolley.PrintData();
                    break;
                case 5:
                    var car = new Sedan();
                    car.PrintData();
                    break;
                case 6:
                    var sportcar = new Formula_1();
                    sportcar.PrintData();
                    break;
                default:
                    break;
            }
        }
    }
}
