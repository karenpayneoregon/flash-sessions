using System.Text.Json;
using BasicLibrary;
using  BasicLibrary.Models;
using BasicsFrontendApp.Classes;
using BasicsFrontendApp.Classes.Helpers;
using BasicsFrontendApp.Classes.OtherStuff;

namespace BasicsFrontendApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Taxpayer1 taxpayer1 = new Taxpayer1
            {
                LastName = "Smith",
                SSN = "123-45-6789"
            };

            var jTest = JsonSerializer.Serialize(taxpayer1,
                new JsonSerializerOptions { WriteIndented = true });
            
            var jTest1 = JsonSerializer.Deserialize<Taxpayer1>(jTest);
            
            var test = Helper.FrameworkDescription;
            var taxpayerList = BogusOperations.TaxpayerList();

            Other.ConvertDataToXml(taxpayerList);

            var value = "A12U34";
            var incrementedValue = Helper.IncrementAlphanumeric(value);
            
            
            
            Console.WriteLine(incrementedValue);

            //Console.WriteLine(ObjectDumper.Dump(taxpayerList));

            Console.ReadLine();
        }

        
    }
}

