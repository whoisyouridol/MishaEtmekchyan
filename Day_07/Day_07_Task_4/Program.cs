using System;

namespace Day_07_Task_4
{
    class Program
    {
        static int CountPower(int num, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            return num * CountPower(num, power - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(CountPower(2,10));
        }
    }
}
