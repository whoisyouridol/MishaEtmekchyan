using System;

namespace Task_1_MishaEtmekchyan
{
    class Program
    {
        static double CountD(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        static double[] CountX1AndX2(double D, double b, double a)
        {
            if (double.IsNaN(Math.Sqrt(D)))
            {
                return null;
            }
            if (Math.Sqrt(D) == 0)
            {
                var result = new double[1];
                result[0] = (-b / (2 * a));
                return result;
            }
            else
            {
                var result = new double[2];
                result[0] = ((-b + Math.Sqrt(D)) / (2 * a));
                result[1] = ((-b - Math.Sqrt(D)) / (2 * a));
                return result;
            }
        }

        static void InputValues(out double a, out double b, out double c)
        {
            Console.WriteLine("Please, input a, b, c : ");
            Console.Write("a : ");
             a = Convert.ToDouble(Console.ReadLine());
            Console.Write("b : ");
             b = Convert.ToDouble(Console.ReadLine());
            Console.Write("c : ");
             c = Convert.ToDouble(Console.ReadLine());
        
        
        }
        static void Main(string[] args)
        {
            double a, b, c;

            InputValues(out a, out b, out c);
            var D = CountD(a, b, c);
            var result = CountX1AndX2(D, b, a);
            if (result != null)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(i + 1 + " element : " + result[i]);
                }    
            }
            

        }
    }
}
