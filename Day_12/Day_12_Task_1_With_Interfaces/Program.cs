using System;

namespace Day_12_Task_1_With_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle();
            var rectangle = new Rectangle();
            var circle = new Circle();

            Console.WriteLine($"Area : {triangle.Area()}");
            Console.WriteLine($"Perimeter : {triangle.Perimeter()}");

            Console.WriteLine($"Area : {rectangle.Area()}");
            Console.WriteLine($"Perimeter : {rectangle.Perimeter()}");

            Console.WriteLine($"Area : {circle.Area()}");
            Console.WriteLine($"Perimeter : {circle.Perimeter()}");

        }
    }
}
