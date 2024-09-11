#nullable disable
using System.Globalization;
using System.Text.RegularExpressions;

namespace Week4_cs;

internal class Program
{
    /*
     *  Class level variables
     */
    private static int pSomeVar = 1;

    static void Main(string[] args)
    {

        foreach (var date in RegularExpressionHelpers.ParseDates("07th December 2022 08 December 2024 01st December 2022"))
        {
            Console.WriteLine(date.ToShortDateString());
        }
        Console.ReadLine(); 
    }

}

public static partial class RegularExpressionHelpers
{

    public static IEnumerable<DateTime> ParseDates(string input)
    {
        var matches = DatesRegex().Matches(input);
        var result = new List<DateTime>(matches.Count);
        var culture = new CultureInfo("en-US");

        foreach (Match match in matches)
        {
            var day = match.Groups["day"].Value;
            var month = match.Groups["month"].Value;
            var year = match.Groups["year"].Value;
            var date = DateTime.ParseExact($"{day}-{month}-{year}", "d-MMMM-yyyy", culture);

            result.Add(date);
        }

        return result;
    }

    [GeneratedRegex(@"(?<day>\d{1,2})((st)|(nd)|(rd)|(th))? (?<month>[A-Za-z]+) (?<year>\d{4})")]
    private static partial Regex DatesRegex();
}

