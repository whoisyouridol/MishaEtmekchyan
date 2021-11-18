using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_1
{
    class Triangle : Shape
    {
      

        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();


        }

        public override double Area()
        {
            var semiperimeter = (Point.CountLength(A,B) + Point.CountLength(B,C) + Point.CountLength(A,C))/ 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - Point.CountLength(A, B)) * (semiperimeter - Point.CountLength(B, C)) * (semiperimeter - Point.CountLength(A, C)));
        }

        public override double Perimeter()
        {
            return Point.CountLength(A, B) + Point.CountLength(B, C) + Point.CountLength(A, C);
        }
    }
}
