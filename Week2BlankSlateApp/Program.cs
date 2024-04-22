using System.Text;
using Week2BlankSlateApp.Interfaces;
using Week2BlankSlateApp.Models;

namespace Week2BlankSlateApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var humans = GetAllHumans();


        foreach (var human in PatternMatching())
        {
            Console.WriteLine($"{human.FirstName} says {human.Hello}");
        };


        Console.ReadLine();
    }

    private static List<IHuman> GetAllHumans()
    {
        List<IHuman> humans =
        [
            new American() { FirstName = "Mary", LastName = "Smith", BirthDate = new DateOnly(1956,1,1)},
            new Vietnamese() { FirstName = "Mai", LastName = "Hai" },
            new Russian() { FirstName = "Kira", LastName = "Sokolov" }
        ];

        return humans;
    }

    private static IEnumerable<IHuman> PatternMatching()
    {

        var humans = GetAllHumans();

        foreach (IHuman human in humans)
        {
            if (human is Vietnamese v)
            {
                yield return v;
            }
            else if (human is American u)
            {
                yield return u;
            }
            else if (human is Russian r)
            {
                yield return r;
            }
        }

    }
}