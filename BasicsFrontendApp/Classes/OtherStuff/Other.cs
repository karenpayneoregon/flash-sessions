using BasicsFrontendApp.Classes.Helpers;
using Newtonsoft.Json;
using System.Xml;
using BasicLibrary.Models;

namespace BasicsFrontendApp.Classes.OtherStuff;

/// <summary>
/// Not part of the learning path, Karen tinkering
/// </summary>
internal class Other
{
    /// <summary>
    /// Given a list of <see cref="BasicLibrary.Models.Taxpayer"/> creates an XML file
    /// </summary>
    /// <param name="taxpayersList">List with at least one record</param>
    public static void ConvertDataToXml(List<Taxpayer> taxpayersList)
    {
        string json = JsonConvert.SerializeObject(
            taxpayersList, Newtonsoft.Json.Formatting.Indented, new TaxpayerJsonConverter(typeof(Taxpayer)));

        ConvertJsonToXml(json);
        SpectreConsoleHelpers.ShowTaxpayers(taxpayersList);
    }
    public static void ConvertJsonToXml(string json)
    {
        
        XmlDocument doc = JsonConvert.DeserializeXmlNode(
            $$"""
            {
                '?xml': {
                '@version': '1.0',
                '@standalone': 'no'
            },
            'Taxpayers':
            {
                'Taxpayer':
                 {{json}}
              }
            }
            """)!;
        doc.Save("People.xml");
    }
}
