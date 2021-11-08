using System;

namespace Day_07_Task_1
{
    class Program
    {
        static int PrintNumbers(int number, int tempNum)
        {
            Console.Write(tempNum + " ");

            if (number == tempNum)
            {
                return number;
            }
            return PrintNumbers(number, tempNum + 1);
        }
        static int PrintNumbersWrapper(int number)
        {
            return PrintNumbers(number, 1);
        }

        static void Main(string[] args)
        {
            PrintNumbersWrapper(13);
        }
    }
}
