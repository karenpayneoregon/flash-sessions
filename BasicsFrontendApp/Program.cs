using BasicsFrontendApp.Classes;
using BasicsFrontendApp.Models;
using BasicsFrontendApp.Classes.Helpers;

namespace BasicsFrontendApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<Taxpayer> taxpayersList= BogusOperations.TaxpayerList();
        SpectreConsoleHelpers.ShowTaxpayers(taxpayersList);
        Console.ReadLine();
    }
}