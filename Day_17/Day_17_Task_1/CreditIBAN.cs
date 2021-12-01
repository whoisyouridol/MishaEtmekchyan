using System;
using System.Collections.Generic;
using System.Text;

namespace Day_17_Task_1
{
    public class CreditIBAN : IBAN
    {
        public decimal CurrentCredit { get; set; }
        public DateTime PaymentDeadLine { get; set; }
    }
}
