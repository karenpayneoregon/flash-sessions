using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using Week4.Classes;
using static System.Globalization.DateTimeFormatInfo;
#nullable disable
namespace Week4;

internal partial class Program
{
    static void Main()
    {
        PeopleExample();
        //UnionExample();
        Console.ReadLine();
        return;
        ISet<string> set = new HashSet<string> { "one", "two", "three" };
        RunRight(set,"three", "four");
        set.ToList().ForEach(Console.WriteLine);

        Console.WriteLine();
        set = new HashSet<string> { "four", "five", "six" };
        RunWrong(set, "six", "seven");
        set.ToList().ForEach(Console.WriteLine);
        Console.ReadLine();
    }

    private static void PeopleExample()
    {
        List<Person> list =
        [
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1976,3,4) },
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24) }
        ];

        List<Person> list1 =
        [
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1976,3,4) },
            new() { Id = 3, FirstName = "Frank", LastName = "Adams", BirthDate = new DateOnly(1966,3,4) },
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24) }
        ];

        ISet<Person> set = new HashSet<Person>(list);

        foreach (var person in list)
        {
            set.Add(person);
        }

        //var overlaps = set.Overlaps(list1);

        //var firstOrDefault = set.FirstOrDefault(x => x.FirstName == "Karen");
        //firstOrDefault.FirstName = "Kate";

        foreach (var person in set)
        {
            Console.WriteLine(person);
        }

        var test = set.ToImmutableList();
    }

    private static void UnionExample()
    {
 
        ISet<Person> set1 = new HashSet<Person>
        {
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1976,3,4) },
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24) }
        };

        ISet<Person> set2 = new HashSet<Person>
        {
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 3, FirstName = "May", LastName = "Gallagher", BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 4, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1976,3,4) }
        };

        set1.UnionWith(set2);

    }

    private static void RunRight(ISet<string> set, params string[] values)
    {
        foreach (var item in values)
        {
            set.Add(item);
        }
    }

    private static void RunWrong(ISet<string> set, params string[] values)
    {
        foreach (var item in values)
        {
            if (set.Contains(item) == false)
            {
                set.Add(item);
            }
            
        }
    }








    private static bool Sample1()
    {
        bool ValidateSsn(string ssn)
        {
            if (ssn.Length != 11)
            {
                return false;
            }

            if (ssn[3] != '-' || ssn[6] != '-')
            {
                return false;
            }

            return int.TryParse(ssn[..3], out _) && int.TryParse(ssn[4..6], out _) && int.TryParse(ssn[^4..], out _);
        }

        var ssn = "123-45-8899";
        //         0123456789


        if (ValidateSsn(ssn))
        {

        }

        {
            if (int.TryParse(ssn[..3], out var firstThree) &&
                int.TryParse(ssn[4..6], out var middleTwo) &&
                int.TryParse(ssn[^4..], out var lastFour))
            {

            }
            else
            {
                return true;
            }

            var newSsn = $"{firstThree}{middleTwo}{lastFour}";
        }


        {

            if (int.TryParse(ssn[..3], out var firstThree))
            {

            }
            if (int.TryParse(ssn[4..6], out var middleTwo))
            {

            }

            if (int.TryParse(ssn[^4..], out var lastFour))
            {

            }
        }


        {
            if (int.TryParse(ssn[..3], out _) && int.TryParse(ssn[4..6], out _) && int.TryParse(ssn[^4..], out _))
            {

            }

        }




        {
            if (int.TryParse(ssn.Replace("-", ""), out var value))
            {

            }
        }



        Console.WriteLine(ssn[^4..]);



        //Console.WriteLine($"{ssn[..3]}{ssn[4..6]}{ssn[^4..]}");
        //Console.WriteLine(ssn.Replace("-",""));

        Console.WriteLine();
        foreach (var item in Months)
        {
            Console.WriteLine($"{item.Index,-3}{item.Name}");
        }

        return false;
    }

    public static List<MonthItem> Months =>
        CurrentInfo.MonthNames[..^1]
            .Select((monthName, index) => new MonthItem(index + 1, monthName))
            .ToList();

    private static void FromVisualBasic()
    {
        string firstName = "Karen";
        string lastName = "Payne";

        List<string> someList = ["one", "two", "three"];

        foreach (string item in someList)
        {
            Console.WriteLine(item);
        }

    }
}

public class MonthItem
{
    public MonthItem(int index, string monthName)
    {
        Index = index;
        Name = monthName;
    }

    public int Index { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}