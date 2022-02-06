using FluentValidation;
using PersonManagement.Infrastructure.Localizations;
using PersonManagement.Models.Request;
using System;
using PersonManagement.Infrastructure.Extensions;

namespace PersonManagement.Infrastructure.Validators
{
    public class PersonRequestValidator : AbstractValidator<PersonRequest>
    {
        public PersonRequestValidator()
        {
            //წესი
            RuleFor(x => x.Identifier)
                .NotEmpty()
                .Length(11)
                .Matches("^[0-9]*$");


            RuleFor(x => x.BirthDate)
            .LessThanOrEqualTo(x => DateTime.Now)
            .WithMessage(ErrorMessages.BirthDate);


            //RuleForEach(x => x.Accounts).SetValidator(new BankAccountValidator());


            //RuleFor(x => x.Age)
            //    .Must(value => value > 18)
            //    .WithMessage(ErrorMessages.AdultAge);


            //When(x => x.IsBankCustomer, () =>
            //{
            //    RuleFor(x => x.Accounts)
            //    .NotNull()
            //    .WithMessage(nameof(PersonRequest.Accounts) + " " + ErrorMessages.NotEmpty);
            //});


            //RuleFor(x => x.Passport)
            //    .Passport();

            //RuleFor(x => x.PhoneNumber)
            //    .Phone();


            ////Rule Sets

            //RuleSet("Post", () =>
            //{
            //    RuleFor(x => x.Id).Empty();
            //});


            //RuleSet("Put", () =>
            //{
            //    RuleFor(x => x.Id).NotEmpty();
            //});z
        }
    }
}
