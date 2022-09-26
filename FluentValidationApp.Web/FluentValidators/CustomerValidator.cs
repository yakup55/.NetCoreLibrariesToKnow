using FluentValidation;
using FluentValidationApp.Web.Migrations;
using FluentValidationApp.Web.Models;
using Microsoft.AspNetCore.Rewrite;
using System;

namespace FluentValidationApp.Web.FluentValidators
{
    // Daha fazla için FluentValidation dökümanına git webden
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} cannot be empty";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Mail).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Mail is not in correct format");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 30).WithMessage("You must be between 18 and 30 years old");
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18)>=x;
            }).WithMessage("You must be over 18 years old");

            RuleForEach(x => x.Adresses).SetValidator(new AddressValidator());

            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} Male=1 Woman=2 Should be");
        }
    }
}
