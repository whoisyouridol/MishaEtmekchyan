using System;

namespace Task_4_MishaEtmekchyan
{
    class Program
    {
        static double CalculatorFor1Num(double num, string operation)
        {

            return operation switch
            {
            "power" => Math.Pow(num, 2),
            "sqrt" => Math.Sqrt(num),
            _ => double.NaN
            };
        }
        static double CalculatorFor2Nums(double a, double b, string operation)
        {
            return operation switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a / b,
                _ => double.NaN,
            };
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Select one of these operations : ");
            Console.WriteLine("+");
            Console.WriteLine("-");
            Console.WriteLine("*");
            Console.WriteLine("/");
            Console.WriteLine("sqrt");
            Console.WriteLine("power");
            string op = Console.ReadLine();
            if (op == "sqrt" || op == "power")
            {
                Console.Write("Input number : ");
                double num = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(CalculatorFor1Num(num,op));
            }
            if (op == "+" || op == "-" || op == "*" || op == "/" )
            {
                Console.Write("Input number 1 : ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Input number 2 : ");

                double num2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(CalculatorFor2Nums(num1,num2, op));
            }
        }
    }
}
