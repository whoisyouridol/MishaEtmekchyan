using System;
using System.Collections.Generic;
using System.Text;

namespace Day_15_Task_1
{
    public class Generic<T> : IMathOperation<T>
    {
        T source;
        public Generic(T param)
        {
            source = param;
        }
        public int Add(int num1, int num2)
        {
            return IMathOperationHelper.AddIntegers((IMathOperation<IntMathOperation>)this, num1, num2);
        }

        public T GetT()
        {
            return source;
        }

      
    }
}
