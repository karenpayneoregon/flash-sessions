using BasicsFrontendApp.Classes.Helpers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace BasicsFrontendApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Basic interfaces and classes examples";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}

    /// <summary>
    /// Conceals the last four digits of a social security number
    /// </summary>
    public class SocialSecurityConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString();
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.MaskSsn());
        }
    }

    public class Taxpayer1
    {
        public string LastName { get; set; }
        [JsonConverter(typeof(SocialSecurityConverter))]
        public string SSN { get; set; }
    }