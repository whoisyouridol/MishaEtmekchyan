using System;

namespace Day_06_Task_4
{
    class Program
    {
        static int GetWordAmount(string str)
        {
            return str.Split().Length;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetWordAmount("First Second Third"));
        }
    }
}
