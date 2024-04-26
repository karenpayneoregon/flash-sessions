using System.Globalization;
using static System.Globalization.DateTimeFormatInfo;
#nullable disable
namespace Week4;

internal partial class Program
{
    static void Main()
    {

        ISet<string> set = new HashSet<string> { "one", "two", "three" };
        RunRight(set,"three", "four");
        set.ToList().ForEach(Console.WriteLine);

        Console.WriteLine();
        set = new HashSet<string> { "four", "five", "six" };
        RunWrong(set, "six", "seven");
        set.ToList().ForEach(Console.WriteLine);
        Console.ReadLine();
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