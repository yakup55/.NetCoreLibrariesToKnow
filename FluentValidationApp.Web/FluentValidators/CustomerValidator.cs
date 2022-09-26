using FluentValidation;
using FluentValidationApp.Web.Migrations;
using FluentValidationApp.Web.Models;
using Microsoft.AspNetCore.Rewrite;
using System;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{ProperyName} cannot be empty";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Mail).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Mail is not in correct format");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 30).WithMessage("You must be between 18 and 30 years old");
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18)>=x;
            }).WithMessage("You must be over 18 years old");
        }
    }
}
