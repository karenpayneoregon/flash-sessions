#pragma warning disable CA1847
namespace BasicsFrontendApp.Classes.Helpers;
public static class StringExtensions
{
    /// <summary>
    /// For demonstration only, for a real application use a mask in the database table based on user permissions,
    /// see Others\readme.md
    /// </summary>
    public static string MaskSsn(this string ssn, int digitsToShow = 4, char maskCharacter = 'X')
    {
        if (string.IsNullOrWhiteSpace(ssn)) return string.Empty;
        if (ssn.Contains("-")) ssn = ssn.Replace("-", string.Empty);
        if (ssn.Length != 9) throw new ArgumentException("SSN invalid length");
        if (ssn.IsNotInteger()) throw new ArgumentException("SSN not valid");

        const int ssnLength = 9;
        const string separator = "-";

        int maskLength = ssnLength - digitsToShow;
        int output = int.Parse(ssn.Replace(separator, string.Empty).Substring(maskLength, digitsToShow));

        var format = string.Empty;
        for (var index = 0; index < maskLength; index++)
        {
            format += maskCharacter;
        }

        for (var index = 0; index < digitsToShow; index++)
        {
            format += "0";
        }

        format = format.Insert(3, separator).Insert(6, separator);
        format = $"{{0:{format}}}";

        return string.Format(format, output);

    }

}
