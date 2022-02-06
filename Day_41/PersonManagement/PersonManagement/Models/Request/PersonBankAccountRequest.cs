using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Models.Request
{
    public class PersonBankAccountRequest
    {
        public string IBAN { get; set; }
        public string CCY { get; set; }
    }
}
