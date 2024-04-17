using SomeLibrary1.Models;
using SomeLibraryFrontEnd.Classes;

namespace SomeLibraryFrontEnd;

internal partial class Program
{
    static void Main(string[] args)
    {
        string line = new string('-', 40);

        
        PersonExample();
        Console.WriteLine(line);

        EmployeeExample();
        Console.WriteLine(line);

        ManagerExample();

        Console.WriteLine();
        AnsiConsole.MarkupLine("[cyan]Abstract Class Example[/]");
        
        Human[] humans = 
            [
                new American() {FirstName = "Mary", LastName = "Smith"}, 
                new Russian() {FirstName = "Kira", LastName = "Sokolov"}
            ];

        foreach (var human in humans)
        {
            if (human is American usa)
            {
                AnsiConsole.MarkupLine($"[lightcyan3]{usa.GetType().Name,-10}[/] {usa.FirstName} says {usa.SayTimeOfDay}");
            }
            else
            {
                AnsiConsole.MarkupLine($"[indianred]{human.GetType().Name,-10}[/] {human.FirstName} says {human.SayTimeOfDay}");
            }
            
        }


        Console.ReadLine();
    }

    private static void PersonExample()
    {
        Person person = new()
        {
            Id = 1, 
            Title = "Mr",                           // no override
            FirstName = "John",                     // has override
            LastName = "Doe",                       // has override
            BirthDate = new DateOnly(2023, 12, 5)   // no override
        };

        person.PerformSimpleTask(1);
        Console.WriteLine();

        person.FirstName = "Mike";

        AnsiConsole.MarkupLine("[cyan]Single Person[/]");
        Console.WriteLine($"{person.Id,-4}{person.Title,-5}{person.FirstName,-10}{person.LastName,-10}{person.BirthDate}");
        Console.WriteLine(person.GetFullName());
    }

    private static void EmployeeExample()
    {
        Employee employee = new()
        {
            Id = 1,
            Title = "Miss",
            FirstName = "Jane",
            LastName = "Doe",
            BirthDate = new DateOnly(2023, 12, 5),
            HireDate = new DateOnly(2023, 12, 5)
        };

        AnsiConsole.MarkupLine("[cyan]Single Employee[/]");
        Console.WriteLine($"{employee.Id,-4}{employee.Title,-5}{employee.FirstName,-10}{employee.LastName,-10}{employee.BirthDate}");
        Console.WriteLine(employee.GetFullName());
        Console.WriteLine($"   {employee.Description}");
    }

    private static void ManagerExample()
    {
        Manager manager = new()
        {
            Id = 1,
            Title = "Mrs",
            FirstName = "May",
            LastName = "Be",
            BirthDate = new DateOnly(2023, 12, 5),
            HireDate = new DateOnly(2023, 12, 5),
            Employees = BogusOperations.EmployeesList()

        };

        AnsiConsole.MarkupLine("[cyan]Single Manager Employees[/]");

        Console.WriteLine($"{manager.Id,-4}{manager.Title,-5}{manager.FirstName,-10}{manager.LastName,-10}{manager.BirthDate}");
        Console.WriteLine(manager.GetFullName());
        Console.WriteLine($"   {manager.Description}");
        Console.WriteLine("       Employees");
        foreach (var employee in manager.Employees)
        {
            Console.WriteLine($"       {employee.Id,-5}{employee.FirstName,-20}{employee.LastName,-20}{employee.HireDate}");
        }
    }
}