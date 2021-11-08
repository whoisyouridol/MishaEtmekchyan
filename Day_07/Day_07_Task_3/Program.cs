using System;

namespace Day_07_Task_3
{
    class Program
    {
        static int CountDigitsInNumber(int number)
        {
            if (number >=1 && number <=9)
            {

                return 1;
            }
            return  1 + CountDigitsInNumber(number / 10);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(CountDigitsInNumber(999));
        }
    }
}
