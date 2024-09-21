using System.Text.Encodings.Web;
using System.Text.Json;

namespace ColorConvert.Writers;

class ColorsJsonWriter : IColorsWritable
{
    public ColorsJsonWriter() {}

    public void WriteToFile(string path, List<ColorValue> colors)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // To prevent escaping of non-ASCII characters
        };
        string json = JsonSerializer.Serialize(colors, options);
        File.WriteAllText(path, json); 
        // If we need to use StreamWriter because the data is too big,
        // the data shouldn't be stored in json format (or any other text format for that matter).
    }
}