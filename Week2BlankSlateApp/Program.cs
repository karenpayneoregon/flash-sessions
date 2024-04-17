using System.Text;
using Week2BlankSlateApp.Interfaces;
using Week2BlankSlateApp.Models;

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


        var result = humans.FirstOrDefault(x => x is Russian);
        if (result is not null)
        {

        }
        else
        {
            Console.WriteLine("Nothing");
        }

        Sample1(humans);


        Console.ReadLine();
    }

    private static void Sample1(List<IHuman> humans)
    {
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
    }
}