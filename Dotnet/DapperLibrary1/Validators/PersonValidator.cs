#nullable disable
using DapperLibrary1.LanguageExtensions;
using DapperLibrary1.Models;
using FluentValidation;

namespace DapperLibrary1.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {

        Include(new FirstLastNameValidator());
        RuleFor(x => x.BirthDate).BirthDateRule();

    }
}