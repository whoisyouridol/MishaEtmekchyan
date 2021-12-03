using System;
using System.Collections.Generic;
using System.Text;

namespace Day_17_Task_1
{
    public class IncorrectInputedAmountException : Exception
    {
        public IncorrectInputedAmountException() : base(string.Format("Inputed data is not correct"))
        {

        }
    }
}
