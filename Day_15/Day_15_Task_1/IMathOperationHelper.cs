using System;
using System.Collections.Generic;
using System.Text;

namespace Day_15_Task_1
{
    public static class IMathOperationHelper
    {
        public static int AddIntegers(IMathOperation<IntMathOperation> intMathOperation, int num1, int num2)
        {
            return intMathOperation.GetT().Add(num1,num2);
        }
    }
}
