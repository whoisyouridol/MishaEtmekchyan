using System;
using System.Collections.Generic;
using System.Text;

namespace Day_11_Task
{
    static class MATH
    {
        public static int Pow(int number,int power ,out Statuses statuses)
        {
            if (power >= 0)
            {
                int result = 1;
                statuses = Statuses.Success;
                for (int i = 0; i < power; i++)
                {
                    result *= number;
                }
                return result;
            }
            else statuses = Statuses.PowMustBeaPositiveOrZero;

            throw new Exception("Power is less than 0");
        }
        public static int GetMin(int num1, int num2, out Statuses statuses)
        {
            statuses = Statuses.Success;

            if (num2 > num1)
            {
                return num1;
            }
            else if(num1 > num2)
            {
                return num2;
            }
            else statuses = Statuses.Equal;
            throw new Exception("These numbers are equal!");
        }
        public static int GetMax(int num1, int num2, out Statuses statuses)
        {
            statuses = Statuses.Success;

            if (num2 > num1)
            {
                return num2;
            }
            else if (num1 > num2)
            {
                return num1;
            }
            else statuses = Statuses.Equal;
            throw new Exception("These numbers are equal!");
        }
    }
}
