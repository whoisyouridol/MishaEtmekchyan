using System;

namespace Day_14_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(1, 2, 3, 4);
            Matrix m2 = new Matrix(1, 4, 5, 2);

            var m3 = m1 * m2;
            Console.WriteLine(m3.ToString());
            Console.WriteLine("_________________________________________");
            var m4 = -m1;
            Console.WriteLine(m4.ToString());

            Console.WriteLine(m4.Equals(m1));
        }
    }
}
