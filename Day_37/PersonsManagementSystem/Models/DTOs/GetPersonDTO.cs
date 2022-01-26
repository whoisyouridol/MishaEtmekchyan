using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsManagementSystem.Models.DTOs
{
    public class GetPersonDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string PersonalWebSiteLink { get; set; }

        public string PhoneNumber { get; set; }

        public string BankCard { get; set; }

    }
}
