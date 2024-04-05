using DapperLibrary1.Interfaces;
using DapperLibrary1.Models;
using FluentValidation;

namespace DapperLibrary1.Validators;

public class FirstLastNameValidator : AbstractValidator<IPerson>
{
    public FirstLastNameValidator()
    {

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(3);

    }
}