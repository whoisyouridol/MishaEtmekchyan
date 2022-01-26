using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using PersonsManagementSystem.Attributes;
namespace PersonsManagementSystem.Models.DTOs
{
    public class AddPersonDTO
    {
        [StringLength(int.MaxValue,MinimumLength = 11)]
        public string PersonalNumber { get; set; }

        [RegularExpression("^[ა-ჰ]*$", ErrorMessage = "Firstname should be written only with georgian characters")]
        public string FirstName { get; set; }

        [RegularExpression("^[ა-ჰ]*$", ErrorMessage = "Lastname should be written only with georgian characters")]
        public string LastName { get; set; }

        [AcceptableAge(13,17)]
        public int Age { get; set; }

        //[EmailAddress] ze vici, magram, regexit mindoda dawera
        [RegularExpression(@"^[a-zA-Z0-9.]+@[a-zA-Z0-9.]+$", ErrorMessage = "Mail is not valid")]
        public string Email { get; set; }

        
        public string PersonalWebSiteLink { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [CreditCard]
        public string BankCard { get; set; }
    }
}