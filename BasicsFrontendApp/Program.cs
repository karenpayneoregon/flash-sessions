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

        string json = JsonConvert.SerializeObject(
            taxpayersList, Newtonsoft.Json.Formatting.Indented, new TaxpayerJsonConverter(typeof(Taxpayer)));
        ConvertJsonToXml(json);
        SpectreConsoleHelpers.ShowTaxpayers(taxpayersList);
        //Console.ReadLine();
    }


    public static void ConvertJsonToXml(string text)
    {

        string json = $$"""
                            {
                                '?xml': {
                                '@version': '1.0',
                                '@standalone': 'no'
                            },
                            'Taxpayers':
                            {
                                'Taxpayer':
                                 {{text}}
                              }
                            }
                        """;

        XmlDocument doc = JsonConvert.DeserializeXmlNode(json)!;
        doc.Save("People.xml");
    }
}