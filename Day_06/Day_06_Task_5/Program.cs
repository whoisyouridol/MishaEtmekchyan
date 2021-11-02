using System;

namespace Day_06_Task_5
{
    class Program
    {
        static int CountLetters(string str)
        {
            str = str.ToUpper();
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    result++;
                }
            }

            return result;
        }
        static int CountNumbers(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >='0' && str[i] <='9')
                {
                    result++;
                }
            }
            return result;

        }
        static int CountOtherSymbols(string str)
        {
            int result = 0;
            str = str.ToUpper();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] < '0' || str[i] > '9') && (str[i] < 'A' || str[i] > 'Z') )
                {
                    result++;
                }
            }
            return result;

        }


        static void PrintAmountOfSymbols(string str, int letters, int numbers, int otherSymbols) 
        {
            Console.WriteLine($"{str} -> letters : {letters}, numbers : {numbers}, other symbols : {otherSymbols}");
        }
        static void Main(string[] args)
        {
            string str = "Hello 1 !";
            int letterAmount = CountLetters(str);
            int numberAmount = CountNumbers(str);
            int otherSymbolsAmount = CountOtherSymbols(str);


            PrintAmountOfSymbols(str, letterAmount, numberAmount, otherSymbolsAmount);
        }
    }
}
