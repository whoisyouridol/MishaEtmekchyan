using FluentValidation;
using PersonManagement.Infrastructure.Localizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.Extensions
{
    public static class ValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, string> Passport<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => Regex.IsMatch(x, @"^[0-9a-zA-Z]+$")).WithMessage(ErrorMessages.Passport);
        }

        public static IRuleBuilderOptions<T, string> Phone<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => Regex.IsMatch(x, @"^5\d{8}$")).WithMessage(ErrorMessages.Passport);
        }
    }
}
