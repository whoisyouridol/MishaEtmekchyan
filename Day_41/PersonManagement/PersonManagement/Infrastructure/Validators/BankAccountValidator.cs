using FluentValidation;
using PersonManagement.Models.Request;


namespace PersonManagement.Infrastructure.Validators
{
    public class BankAccountValidator : AbstractValidator<PersonBankAccountRequest>
    {
        public BankAccountValidator()
        {
            RuleFor(x => x.IBAN)
                .Length(16)
                .Matches("^[a-zA-Z0-9]*$")
                .WithMessage(nameof(PersonBankAccountRequest.IBAN) + " must be 16 digits");

            RuleFor(x => x.CCY)
               .Length(3)
               .Matches("^[a-zA-Z]*$")
               .WithMessage(nameof(PersonBankAccountRequest.CCY) + " must be 3 symbols");
        }
    }
}
