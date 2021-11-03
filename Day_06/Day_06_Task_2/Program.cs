using System;

namespace Day_06_Task_2
{
    class Program
    {
        static string ReverseString(string str)
        {
            string result = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ReverseString("Hello"));
        }
    }
}
