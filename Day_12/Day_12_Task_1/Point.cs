using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_1
{
    public class Point
    {
  
        public double X { get; set; }
        public double Y { get; set; }

        public Point()
        {
            Console.Write("Enter coords. X : ");
            X = Convert.ToDouble(Console.ReadLine());

            Console.Write("Y : ");
            Y = Convert.ToDouble(Console.ReadLine());
        }

        public static double CountLength(Point v1, Point v2)
        {
            return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow((v1.Y - v2.Y), 2));
        }
    }
}
