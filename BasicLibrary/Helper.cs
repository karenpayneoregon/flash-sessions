using System.Runtime.InteropServices;

namespace BasicLibrary;
public class Helper
{
    public static string FrameworkDescription 
        => RuntimeInformation.FrameworkDescription;

    public static string IncrementAlphanumeric(string input)
    {
        // Split the input into numeric and alphabetical parts
        var numericPart = new string(input.TakeWhile(char.IsDigit).ToArray());
        var alphaPart = new string(input.SkipWhile(char.IsDigit).ToArray());
        // Increment the numeric part
        if (!string.IsNullOrEmpty(numericPart))
        {
            var numericValue = int.Parse(numericPart);
            numericPart = (numericValue + 1).ToString();
        }
        
        
        // Increment the alphabetical part
        if (!string.IsNullOrEmpty(alphaPart))
        {
            var lastChar = alphaPart.Last();
            if (lastChar != 'Z')
            {
                lastChar++;
            }
            else
            {
                lastChar = 'A';
                alphaPart = alphaPart[..^1];
            }
            alphaPart += lastChar;
        }
        return numericPart + alphaPart;
    }

}
