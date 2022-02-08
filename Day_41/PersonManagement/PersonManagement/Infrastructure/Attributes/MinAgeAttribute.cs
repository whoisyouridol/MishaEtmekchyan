using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.Attributes
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public MinAgeAttribute(int minAge)
        {
            this._minAge = minAge;
        }

        public override bool IsValid(object value)
        {
            if(value is DateTime)
            {
                var dateOfBirth = (DateTime)value;

                var diff = DateTime.Now - dateOfBirth;
                var zeroTime = new DateTime(1, 1, 1);

                return (zeroTime + diff).Year >= _minAge;
            }

            return base.IsValid(value); 
        }
    }
}
