using BasicsFrontendApp.Classes.Helpers;
using BasicsFrontendApp.Models;
using Newtonsoft.Json;
using System.Xml;

namespace BasicsFrontendApp.Classes.OtherStuff;

/// <summary>
/// Not part of the learning path, Karen tinkering
/// </summary>
internal class Other
{
    /// <summary>
    /// Given a list of <see cref="Taxpayer"/> creates an XML file
    /// </summary>
    /// <param name="taxpayersList">List with at least one record</param>
    private static void ConvertDataToXml(List<Taxpayer> taxpayersList)
    {
        string json = JsonConvert.SerializeObject(
            taxpayersList, Newtonsoft.Json.Formatting.Indented, new TaxpayerJsonConverter(typeof(Taxpayer)));
        ConvertJsonToXml(json);
        SpectreConsoleHelpers.ShowTaxpayers(taxpayersList);
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
