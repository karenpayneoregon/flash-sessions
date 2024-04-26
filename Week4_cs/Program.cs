#nullable disable
namespace Week4_cs;

internal class Program
{
    /*
     *  Class level variables
     */
    private static int pSomeVar = 1;

    static void Main(string[] args)
    {
        // declare variable
        var strFirstName = "Karen";
        string strLastName = "Payne";

        List<string> someList = ["Karen", "Payne"];

        // loop through list
        // and print out each item
        foreach (var item in someList)
        {
            Console.WriteLine(item);
        }

        ChangeValue();
        Console.WriteLine(pSomeVar);

        Console.ReadLine(); 
    }

    private static void ChangeValue()
    {
        pSomeVar = 2;
    }

    public Program()
    {
        DateTime dateTime = new DateTime(1956, 1, 1, 1, 1, 1);
        DateOnly date = new DateOnly(1956, 1, 1);
        TimeOnly time = new TimeOnly(13, 1, 2);
    }
}

public class SqlStatements
{
    public SqlStatements()
    {
        //
    }
    public string InsertPeople() => 
        """
        INSERT INTO dbo.Person
        (
            FirstName,
            LastName,
            BirthDate
        )
        VALUES
        (@FirstName, @LastName, @BirthDate);
        SELECT CAST(scope_identity() AS int);
        """;
}