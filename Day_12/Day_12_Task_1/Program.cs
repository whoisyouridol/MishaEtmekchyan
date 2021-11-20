using System;

namespace Day_12_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new Shape[3];

            Console.WriteLine("Enter triangle`s coords : ");
            shapes[0] = new Triangle();

            Console.WriteLine("Enter rectangle`s coords : ");
            shapes[1] = new Rectangle();

            Console.WriteLine("Enter circle`s coords : ");
            shapes[2] = new Circle();


            foreach (var shape in shapes)
            {
                Console.WriteLine($"Area : {shape.Area()}");
                Console.WriteLine($"Perimeter : {shape.Perimeter()}");
            }
        }
    }
}
