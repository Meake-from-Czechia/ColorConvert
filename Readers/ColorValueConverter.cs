using System.Text.Json;
using System.Text.Json.Serialization;

namespace ColorConvert.Readers;

public class ColorValueConverter : JsonConverter<ColorValue>
{
    private readonly ColorValueFactory _factory = new ColorValueFactory();

    public override ColorValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var jsonObject = doc.RootElement;
            string name = jsonObject.GetProperty("Name").GetString();
            string type = jsonObject.GetProperty("Type").GetString();
            string value = jsonObject.GetProperty("Value").GetString();

            string[] line = { name, type, value };
            return _factory.CreateColorValue(line);
        }
    }

    // Not used, so not implemented
    public override void Write(Utf8JsonWriter writer, ColorValue value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Tried to use custom converter for writing");
    }
}