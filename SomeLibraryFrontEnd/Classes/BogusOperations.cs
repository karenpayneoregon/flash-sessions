using Bogus;
using SomeLibrary1.Models;
using static Bogus.Randomizer;

namespace SomeLibraryFrontEnd.Classes;
internal class BogusOperations
{
    public static List<Employee> EmployeesList(int count = 5)
    {
        Seed = new Random(338);
        var id = 1;
        var faker = new Faker<Employee>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(e => e.HireDate, f => f.Date.BetweenDateOnly(new DateOnly(1999, 1, 1),
                new DateOnly(2010, 1, 1)));


        return faker.Generate(count);

    }
}
