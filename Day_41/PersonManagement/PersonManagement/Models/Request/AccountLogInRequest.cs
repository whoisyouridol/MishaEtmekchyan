using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Models.Request
{
    public class AccountLogInRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool  IsVerified { get; set; }
    }
}
