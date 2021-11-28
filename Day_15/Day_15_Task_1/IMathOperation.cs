using System;
using System.Collections.Generic;
using System.Text;

namespace Day_15_Task_1
{
    public interface IMathOperation<out T>
    {
        T GetT();
        int Add(int num1,int num2);
    }
}
