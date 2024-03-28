namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {


        Console.Title = "";
        var accountNumber = "0000000124001369";
        Console.WriteLine(accountNumber);
        Console.WriteLine(accountNumber.TrimLeading());
        accountNumber = "0000000124001369";
        Console.WriteLine(accountNumber[^9..]);
        Console.WriteLine(accountNumber.TrimStart('0'));
        Console.ReadLine();
    }
}

public static class StringExtensions
{
    public static string TrimLeading(this string input, char trimChar = '0')
        => input.TrimStart([trimChar]);
}

