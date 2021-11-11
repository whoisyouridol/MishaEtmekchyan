using System;

namespace Day_09_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var clock = new Clock();
            Console.Write("Enter hours : ");
            clock.Hours = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter minutes : ");
            clock.Minutes = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter seconds : ");
            clock.Seconds = Convert.ToInt32(Console.ReadLine());
            clock.SetTime();
            clock.AddSecond();
            clock.AddSecond();
            clock.AddSecond();
            clock.GetCurrentTime();


        }
    }
}
