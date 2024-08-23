using System.Runtime.CompilerServices;
using FormattableStringSamples.Classes;
using FormattableStringSamples.Models;

namespace FormattableStringSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        PersonFormat();
        //DayOfWeekExample();
        //InsertStatementExample();


        Person person = new() { Id = 1, FirstName = "Karen", LastName = "Payne" };
        Manager manager = new() { Id = 2, FirstName = "Sam", LastName = "Smith" };

        Console.WriteLine(EmailTemplate(person, manager));
        Console.ReadLine();
    }

    /// <summary>
    /// Example for creating a <seealso cref="FormattableString"/> which is then passed to another method
    /// to display arguments
    /// </summary>
    private static void PersonFormat()
    {
        Person person = new()
        {
            Id = 1, 
            FirstName = "Karen", 
            LastName = "Payne", 
            BirthDate = new DateOnly(1956,9,24)
        };

        FormattableString format = FormattableStringFactory.Create("Id: {0} First {1} Last {2} Birth {3}",
            person.Id, person.FirstName, person.LastName, person.BirthDate);

        DisplayPerson(format);
        Console.WriteLine();
        //SimpleEmailTemplate();
    }

    private static string EmailTemplate(Person person, Manager manager) =>
        FormattableStringFactory.Create(
                """
                Hello {0} {1},

                Welcome to the world C#.

                {2} {3}
                """, 
                person.FirstName, person.LastName, manager.FirstName, manager.LastName)
            .ToString();

    /// <summary>
    /// Example for viewing arguments in a <seealso cref="FormattableString"/>
    /// </summary>
    private static void DisplayPerson(FormattableString sender)
    {
        Console.WriteLine($"# Arguments : {sender.ArgumentCount}");
        Console.WriteLine($"Properties  : {sender.ArgumentsJoined()}");

        if (sender.LastName() == "Payne")
        {
            sender.UpdateLastName("Adams");
        }

        Console.WriteLine($"Changed     : {sender.ArgumentsJoined()}");
        Console.WriteLine();
        Console.WriteLine("Properties using extension methods");
        Console.WriteLine($"First name: {sender.FirstName()}");
        Console.WriteLine($" Last name: {sender.LastName()}");
        Console.WriteLine($"Birth Date: {sender.BirthDate()}");


    }

    /// <summary>
    /// Example for viewing arguments in a <seealso cref="FormattableString"/>
    /// </summary>
    private static void DayOfWeekExample()
    {

        FormattableString format = FormattableStringFactory.Create("The weekend {0} {1} {2}",
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday);

        Console.WriteLine($"Format      : {format.Format}");
        Console.WriteLine($"# Arguments : {format.ArgumentCount}");
        Console.WriteLine($"Arguments   : {string.Join(",", format.GetArguments())}");

        for (var index = 0; index < format.ArgumentCount; index++)
        {
            Console.WriteLine($"{index,-4}{format.GetArguments()[index]}");
        }
    }

    /// <summary>
    /// Example for manipulating a SQL Insert statement
    /// DO NOT use in a real application, for demonstration only
    /// </summary>
    private static void InsertStatementExample()
    {
        AnsiConsole.MarkupLine("[cyan]SQL Insert parameters[/]");
        var sql = InsertStatementExample("Karen", "Payne", new DateOnly(1960, 12, 25));
        var (sqlFormat, parameter) = sql.ToParameter();
        Console.WriteLine(sqlFormat);

    }

    private static FormattableString InsertStatementExample(string firstName, string lastName, DateOnly birthDate) =>
        $"""
         INSERT INTO dbo.Person
         (
             FirstName,
             LastName,
             BirthDate
         )
         VALUES
         ({firstName}, {lastName}, {birthDate});
         SELECT CAST(scope_identity() AS int);
         """;
}