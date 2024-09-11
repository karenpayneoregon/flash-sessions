using Microsoft.EntityFrameworkCore;
using QuerySplitting.Data;

namespace QuerySplitting;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        using var context = new Context();
        var list = context
            .Products
            .Include(p => p.Category)
            //.AsSplitQuery()
            .AsSingleQuery()
            .ToList();
        Console.ReadLine();
    }
}