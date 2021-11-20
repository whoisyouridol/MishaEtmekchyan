using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_1
{
    class Circle : Shape
    {
        public Point Center { get; set; }
        public Point A { get; set; }

        public Circle()
        {
            Center = new Point();
            A = new Point();
        }
        public override double Area()
        {
            return Math.Pow(Point.CountLength(Center, A), 2) * Math.PI;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Point.CountLength(Center, A) ;
        }
    }
}
