using System;

namespace Day_14_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tr1 = new Triangle(3, 4, 5);
            var tr2 = new Triangle(4, 5, 6);
            var tr1_copy = tr1;

            Console.WriteLine(tr1.CountPerimeter());
            Console.WriteLine(tr1 < tr2);
            Console.WriteLine(tr1 > tr2);
            Console.WriteLine(tr1 == tr1_copy);

            var tr3 = (Triangle)10.25;

        }
    }
}
