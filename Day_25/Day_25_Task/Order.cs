using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Day_25_Task
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Date { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public int CustomerID { get; set; }

        public override string ToString()
        {
            return $"OrderId : {OrderID}, Date : {Date}, Product : {Product}, Price : {Price}, CustomerId : {CustomerID}";
        }
    }
}
