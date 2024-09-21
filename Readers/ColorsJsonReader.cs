using System.Text.Json;

namespace ColorConvert.Readers;

class ColorsJsonReader : IColorsReadable
{
    public ColorsJsonReader()
    {
    }

    public List<ColorValue> ReadColors(string path)
    {
        List<ColorValue> colors = new List<ColorValue>();
        var options = new JsonSerializerOptions();
        options.Converters.Add(new ColorValueConverter());
        try
        {
            string json = File.ReadAllText(path);
            colors = JsonSerializer.Deserialize<List<ColorValue>>(json, options);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey(true);
            Environment.Exit(16);
        }

        return colors;
    }
}


