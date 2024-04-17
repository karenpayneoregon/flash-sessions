using System.Runtime.CompilerServices;
using BasicLibrary.Models;

namespace BasicsFrontendApp.Classes.Helpers;

public static class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit[/]")
            .RuleStyle(Style.Parse("silver")).LeftJustified());

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    public static void PrintCyan([CallerMemberName] string methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]{methodName}[/]");
        Console.WriteLine();
    }




    /// <summary>
    /// Defines a table for <see cref="ShowTaxpayers"/>
    /// </summary>
    /// <returns></returns>
    public static Table CreateTaxpayerTable()
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[b]Id[/]")
            .AddColumn("[b]Job title[/]")
            .AddColumn("[b]First[/]")
            .AddColumn("[b]Last[/]")
            .AddColumn("[b]Gender[/]")
            .AddColumn("[b]Birth date[/]")
            .AddColumn("[b]SSN[/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey);
        return table;
    }

    /// <summary>
    /// Used to present a list of <see cref="BasicLibrary.Models.Taxpayer"/> in a table
    /// </summary>
    /// <param name="list">One or more taxpayers</param>
    public static void ShowTaxpayers(List<Taxpayer> list)
    {
        var table = CreateTaxpayerTable();

        foreach (var taxpayer in list)
        {
            table.AddRow(
                taxpayer.Id.ToString(),
                taxpayer.JobTitle,
                taxpayer.FirstName,
                taxpayer.LastName,
                taxpayer.Gender.ToString(),
                taxpayer.BirthDate.ToString("MM/dd/yyyy"),
                taxpayer.SSN.MaskSsn(5));
        }

        AnsiConsole.MarkupLine("[cyan]List of taxpayers[/]");
        AnsiConsole.Write(table);
    }
}