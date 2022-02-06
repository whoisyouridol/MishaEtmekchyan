using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Services.Models
{
    public class UserServiceModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public string GUID { get; set; }
    }
}
