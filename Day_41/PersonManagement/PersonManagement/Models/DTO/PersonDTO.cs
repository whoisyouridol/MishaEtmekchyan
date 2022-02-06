using PersonManagement.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Models.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }

        //[MinLength(2)]
        //[MaxLength(50)]
        //[GeorgianOnly]
        public string FirstName { get; set; }

        //[MinLength(2)]
        //[MaxLength(50)]
        //[GeorgianOnly]
        public string LastName { get; set; }

        //[MinLength(11)]
        //[MaxLength(11)]
        public string Identifier { get; set; }

        public bool Gender { get; set; }

        //[MinAge(18)]
        public DateTime BirthDate { get; set; }

        public string Age { get; set; }

        public string City { get; set; }
    }
}
