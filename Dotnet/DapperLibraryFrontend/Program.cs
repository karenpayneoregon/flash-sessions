using DapperLibrary1.Models;
using DapperLibrary1.Repositories;
using DapperLibrary1.Validators;
using DapperLibraryFrontend.MockingClasses;

namespace DapperLibraryFrontend;

internal partial class Program
{
    static async Task Main()
    {

        PersonRepository repo = new();
        
        var recordCount = await repo.RecordCount();

        await repo.ResetPersonTable();
        recordCount = await repo.RecordCount();

        
        var (success, exception) = await repo.AddRange(BogusOperations.People(5));
        recordCount = await repo.RecordCount();

        var allPeople = await repo.GetAllAsync();

        var person = await repo.GetByPrimaryKey(1);

        await UpdatePerson(person, repo);

        Person newPerson = new()
        {
            FirstName = "Mary",
            LastName = "Doe",
            BirthDate = new DateOnly(2023, 12, 5)
        };
  
        await repo.Add(newPerson);

        var anotherPerson = await repo.GetByFirstLastName("May", "Schuster");
        if (anotherPerson is not null)
        {
            var deleted = await repo.Remove(anotherPerson);
        }

        
        ValidatePerson();

    }

    /// <summary>
    /// In this method validation fails because the first and last name are not set
    /// and have rules that they must be set.
    /// </summary>
    private static void ValidatePerson()
    {
        Person person = new()
        {
            BirthDate = new DateOnly(2023, 12, 5)
        };

        PersonValidator validator = new();
        var validate = validator.Validate(person);

        person.FirstName = "John";
        person.LastName = "Doe";
        validate = validator.Validate(person);

    }
    private static async Task UpdatePerson(Person person, PersonRepository repo)
    {
        person.FirstName = "John";
        person.LastName = "Doe";
        person.BirthDate = new DateOnly(2023, 12, 5);

        PersonValidator validator = new();
        var validate = await validator.ValidateAsync(person);
        if (validate.IsValid)
        {
            var (success, exception) = await repo.Update(person);
            if (success)
            {
                
            }
            else
            {
                
            }
        }
        else
        {
            var errors = validate.Errors;
        }

    }
}