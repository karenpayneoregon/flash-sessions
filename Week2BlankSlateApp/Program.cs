using Week2BlankSlateApp.Classes;

namespace Week2BlankSlateApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<IHuman> humans =
        [
            new American() { FirstName = "Mary", LastName = "Smith" },
            new Vietnamese() { FirstName = "Mai", LastName = "Hai" },
            new Russian() { FirstName = "Kira", LastName = "Sokolov" }
        ];

        const int typeIndent = -15;

        foreach (var human in humans)
        {
            if (human is Vietnamese v)
            {
                AnsiConsole.MarkupLine($"[yellow3_1]{v.GetType().Name,typeIndent} {v.FirstName} says {v.SayTimeOfDay}[/]");
            }
            else if (human is American u)
            {
                AnsiConsole.MarkupLine($"[lightcoral]{u.GetType().Name,typeIndent} {u.FirstName} says {u.SayTimeOfDay}[/]");
            }
            else if (human is Russian r)
            {
                AnsiConsole.MarkupLine($"[chartreuse3]{r.GetType().Name,typeIndent} {r.FirstName} says {r.SayTimeOfDay}[/]");
            }

        }


        Console.ReadLine();
    }
}








public enum Language
{
    American,
    Russian,
    Vietnamese,
    Netural
}

public interface IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    protected abstract Language Language { get; }
    public abstract string SayTimeOfDay { get; }
}

public class Human : IHuman
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Language Language => Language.Netural;
    public string SayTimeOfDay
        => Language.SayHello();
}

internal class American : IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Language Language => Language.American;
    public  string SayTimeOfDay
        => Language.SayHello();
}

internal class Russian : IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Language Language => Language.Russian;
    public string SayTimeOfDay
        => Language.SayHello();
}

internal class Vietnamese : IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Language Language => Language.Vietnamese;
    public string SayTimeOfDay
        => Language.SayHello();
}