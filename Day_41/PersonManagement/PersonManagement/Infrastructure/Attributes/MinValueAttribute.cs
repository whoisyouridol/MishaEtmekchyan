using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.Attributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int _min;

        public MinValueAttribute(int min)
        {
            _min = min;
        }

        public override bool IsValid(object value)
        {
            if(value is int)
            {
                return (int)value >= _min;
            }
            return base.IsValid(value);
        }
    }
}
