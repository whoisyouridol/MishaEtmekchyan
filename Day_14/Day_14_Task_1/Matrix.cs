using System;
using System.Collections.Generic;
using System.Text;

namespace Day_14_Task_1
{
    public class Matrix
    {
        public double[,] Elements { get; set; }
        public Matrix(double a, double b, double c, double d)
        {
            Elements = new double[,]
              {
                  {a,b },
                  {c,d }
              };
        }
        private static double[,] _getElements(Matrix matrix)
        {
            return new double[,]
              {
                { matrix.Elements[0,0],matrix.Elements[0,1] },
                { matrix.Elements[1,0],matrix.Elements[1,1] }
            };
        }
        public static implicit operator double (Matrix matrix)
        {
            return _getElements(matrix)[0, 0] * _getElements(matrix)[1, 1] - _getElements(matrix)[0, 1] * _getElements(matrix)[1,0] ;
        }
        public static Matrix operator * (Matrix m1, Matrix m2)
        {
            return new Matrix(
                m1.Elements[0, 0] * m2.Elements[0,0] + m1.Elements[0,1] * m2.Elements[1,0],
                m1.Elements[0, 0] * m2.Elements[0, 1] + m1.Elements[0, 1] * m2.Elements[1, 1],
                m1.Elements[1, 0] * m2.Elements[0, 0] + m1.Elements[1, 1] * m2.Elements[1, 0],
                m1.Elements[1, 0] * m2.Elements[0, 1] + m1.Elements[1, 1] * m2.Elements[1, 1]);
        }
        public static Matrix operator -(Matrix matrix)
        {
            double det = matrix;
            var adjMatrix = new Matrix(
                matrix.Elements[1, 1], -matrix.Elements[0, 1], 
                -matrix.Elements[1, 0], matrix.Elements[0, 0]);
            return new Matrix(
                1/det * adjMatrix.Elements[0, 0],
                1/det * adjMatrix.Elements[0, 1],
                1/det * adjMatrix.Elements[1, 0],
                1/det * adjMatrix.Elements[1, 1]);
        }
        public override string ToString()
        {
            return $"{Elements[0,0]}    {Elements[0,1]}\n" +
                $"{Elements[1,0]}   {Elements[1,1]}";
        }
        public override bool Equals(object matrix)
        {
            var converted = (Matrix)matrix;
            return converted.Elements[0, 0] == Elements[0, 0] &&
                   converted.Elements[0, 1] == Elements[0, 1] &&
                   converted.Elements[1, 0] == Elements[1, 0] &&
                   converted.Elements[1, 1] == Elements[1, 1];
        }
    }
}
