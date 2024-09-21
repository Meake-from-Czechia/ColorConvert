using System.Xml.Linq;

namespace ColorConvert.Readers;

class ColorsXmlReader : IColorsReadable
{
    public ColorsXmlReader()
    {
    }

    public List<ColorValue> ReadColors(string path)
    {
        List<ColorValue> colors = new List<ColorValue>();
        var factory = new ColorValueFactory();
        try
        {
            var doc = XDocument.Load(path);
            foreach (var element in doc.Descendants("Color"))
            {
                string[] line = new string[]
                {
                    element.Element("Name")?.Value,
                    element.Element("Type")?.Value,
                    element.Element("Value")?.Value
                };
                colors.Add(factory.CreateColorValue(line));
            }
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