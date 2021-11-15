using System;

namespace Day_11_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1
            var status = Statuses.Undefined;
            int num, power;
            Console.Write("Please, enter the number : ");
            num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please, enter the power : ");
            power = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(MATH.Pow(num, power, out status));

            //2
            var status_1 = Statuses.Undefined;
            int num1, num2;
            Console.Write("Please, enter the number 1 : ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please, enter the number 2 : ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{MATH.GetMin(num1, num2, out status_1)} is less!");

            //3
            var status_2 = Statuses.Undefined;
            int num3, num4;
            Console.Write("Please, enter the number 1 : ");
            num3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please, enter the number 2 : ");
            num4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{MATH.GetMax(num3, num4, out status_2)} is more!");

        }
    }
}
