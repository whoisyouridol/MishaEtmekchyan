using System;

namespace PersonManagement.Services.Models
{
    public class PersonServiceModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonIdentifier { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public City City { get; set; }
    }
}
