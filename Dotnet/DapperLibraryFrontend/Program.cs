using DapperLibrary1.Models;
using DapperLibrary1.Repositories;
using DapperLibraryFrontend.MockingClasses;
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace DapperLibraryFrontend;

internal partial class Program
{
    static async Task Main()
    {

        PersonRepository repo = new();
        
        Console.WriteLine($"Record count: {await repo.RecordCount()}");


        await repo.ResetPersonTable();
        Console.WriteLine($"Record count: {await repo.RecordCount()}");


        await repo.AddRange(BogusOperations.People(5));
        Console.WriteLine($"Record count: {await repo.RecordCount()}");

        var person = await repo.GetByPrimaryKey(1);

        person.FirstName = "John";
        person.LastName = "Doe";
        person.BirthDate = new DateOnly(2023, 12, 5);
        
        var (success, exception) = await repo.Update(person);
        if (success)
        {
            Console.WriteLine("Person updated");
        }
        else
        {
            Console.WriteLine($"Failed to update person\n{exception.Message}");
        }

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

        
        //Console.ReadLine();
    }
}