using BasicsFrontendApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BasicsFrontendApp.Classes.Helpers;

/// <summary>
/// Custom serializer to mask SSN
/// </summary>
public class TaxpayerJsonConverter : JsonConverter
{
    private readonly Type[] _types;
    public TaxpayerJsonConverter(params Type[] types)
    {
        _types = types;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JToken token = JToken.FromObject(value!);
        JObject jObect = (JObject)token;

        if (value is Taxpayer)
        {
            jObect[nameof(Taxpayer.SSN)] =
                jObect.Value<string>(nameof(Taxpayer.SSN)).MaskSsn();

            jObect[nameof(Taxpayer.SocialSecurityValue)] =
                jObect.Value<string>(nameof(Taxpayer.SocialSecurityValue)).MaskSsn();
        }
        serializer.Serialize(writer, jObect, typeof(Taxpayer));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException("The type will skip the converter.");
    }

    public override bool CanRead => false;
    public override bool CanConvert(Type objectType) => _types.Any(t => t == objectType);
}