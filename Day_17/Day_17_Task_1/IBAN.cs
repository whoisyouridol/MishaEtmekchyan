using System;
using System.Collections.Generic;
using System.Text;

namespace Day_17_Task_1
{
    public class IBAN
    {
        public string BankAccount { get; set; }
        public decimal Amount { get; set; }
        public override string ToString()
        {
            return $"Bank account : {BankAccount}, amount on this account : {Amount}";
        }
        public void AddAmount(decimal a)
        {
            Amount += a; 
        }
        public void GetAmount(decimal a)
        {
            Amount -= a;
        }
    }
}
