using BasicsFrontendApp.Classes;
using BasicsFrontendApp.Models;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BasicsFrontendApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<Taxpayer> taxpayersList= BogusOperations.TaxpayerList();
    }
}