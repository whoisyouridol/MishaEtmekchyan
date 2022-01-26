using System;
using System.Collections.Generic;
using System.Text;

namespace UsersManagementService.Models
{
     public class PersonModel
    {
        public int Id { get; set; }

        public string PersonalNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string PersonalWebSiteLink { get; set; }

        public string PhoneNumber { get; set; }

        public string BankCard{ get; set; }

    }
}