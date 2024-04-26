using  BasicLibrary.Models;
using BasicsFrontendApp.Classes;

namespace BasicsFrontendApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var taxpayerList = BogusOperations.TaxpayerList();

            Console.WriteLine(ObjectDumper.Dump(taxpayerList));
        }

        
    }
}

