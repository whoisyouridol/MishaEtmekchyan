using System;


namespace PersonManagement.Models.Request
{
    public class PersonPutRequest
    {
        public int Id { get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Identifier { get; set; }

        public string Passport { get; set; }

        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
