using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.Attributes
{
    public sealed class GeorgianOnlyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var str = value as string;

            return string.IsNullOrWhiteSpace(str) || str.All(IsGeorgianLetter);
        }

        private bool IsGeorgianLetter(char c)
        {
            var charCode = (int)c;

            return charCode >= 'ა' && charCode <= 'ჰ';
        }
    }
}
