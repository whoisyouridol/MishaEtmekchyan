using System;
using System.Collections.Generic;
using System.Text;

namespace AdminService.ServiceModels
{
    public class ValidateAccountsServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var instance = (ValidateAccountsServiceModel)obj;
            if (instance.Id == Id && instance.Username == Username && instance.Name == Name)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
