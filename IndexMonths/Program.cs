using IndexMonths.Classes;

namespace IndexMonths
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            var list = Helpers.MonthNames();
            var monthContainer = Helpers.RangeDetails(list);
            var table = CreateTable();
            monthContainer.ForEach(x => table.AddRow(x.ItemArray));

            AnsiConsole.Write(table);

            ExitPrompt();
        }
    }
}