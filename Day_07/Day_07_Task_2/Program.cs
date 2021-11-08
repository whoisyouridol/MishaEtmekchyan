using System;

namespace Day_07_Task_2
{
    class Program
    {
        static int GetSum(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            return GetSum(number - 1) + number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetSum(13));
        }
    }
}
