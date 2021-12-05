using System;
using System.Collections.Generic;
using System.Text;

namespace Day_18_Task_1
{
    public interface ILinkedItem<T> : IEnumerable<T>
    {
        void AddItem(T value);
        bool Exists();
        void RemoveItem(T data);
        void PrintItems();
    }
}
