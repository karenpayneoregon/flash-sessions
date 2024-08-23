using System.Text.RegularExpressions;

namespace ConsoleApp1;
public static partial class RegularExpressionHelpers
{
    public static string ExtractName(this string text)
    {
        var match = NameRegex().Match(text);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }


    [GeneratedRegex(@"\[(.*?)\]")]
    private static partial Regex NameRegex();
}