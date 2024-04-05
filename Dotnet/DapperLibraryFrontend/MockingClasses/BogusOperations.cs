using Bogus;
using Person = DapperLibrary1.Models.Person;
using static Bogus.Randomizer;

namespace DapperLibraryFrontend.MockingClasses;
internal class BogusOperations
{
    public static List<Person> People(int count = 20)
    {
        
        Seed = new Random(338);

        return new Faker<Person>()
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.LastName, f => f.Person.LastName)
            .RuleFor(c => c.BirthDate, f =>
                f.Date.BetweenDateOnly(new DateOnly(1999, 1, 1),
                    new DateOnly(2010, 1, 1)))
            .Generate(count);
    }

    public static Person Person() => People(1).First();
}
