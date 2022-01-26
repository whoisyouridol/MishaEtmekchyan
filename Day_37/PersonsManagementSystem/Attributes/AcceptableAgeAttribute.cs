using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsManagementSystem.Attributes
{
    public class AcceptableAgeAttribute : ValidationAttribute
    {
        private int _minAge;
        private int _maxAge;
        public AcceptableAgeAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var age = (int)value;
            return (age > _minAge && age < _maxAge) ? ValidationResult.Success : new ValidationResult("This age is not acceptable!");
        }
    }
}
