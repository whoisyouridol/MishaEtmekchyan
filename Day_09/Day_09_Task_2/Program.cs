using System;

namespace Day_09_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle();

            Console.Write(" Enter first side : ");
            triangle.Side1 = Convert.ToInt32(Console.ReadLine());

            Console.Write(" Enter second side : ");
            triangle.Side2 = Convert.ToInt32(Console.ReadLine());

            Console.Write(" Enter third side : ");
            triangle.Side3 = Convert.ToInt32(Console.ReadLine());


            if (triangle.IsTriangle())
            {
                Console.WriteLine($"Perimeter is : {triangle.CountPerimeter()}");
                Console.WriteLine($"Area is : {triangle.CountArea()}");
            }
            else
            {
                Console.WriteLine("This parameters aren`t valid.");
            }
        }
    }
}
