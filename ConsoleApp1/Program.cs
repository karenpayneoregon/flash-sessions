

using ClassLibrary1;
using ClassLibrary1.Models;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {

        Person person = new Person()
        {
            Id = 1,
            FirstName = "Karen",
            LastName = "Payne",
            BirthDate = new DateOnly(1956, 9, 24),
            Gender = Gender.Female
        };
    }
}



