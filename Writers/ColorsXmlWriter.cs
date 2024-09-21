using System.Xml.Linq;

namespace ColorConvert.Writers;

class ColorsXmlWriter : IColorsWritable
{
    public ColorsXmlWriter() {}

    public void WriteToFile(string path, List<ColorValue> colors)
    {
        var doc = new XDocument(
            new XElement("Colors",
                colors.Select(color => 
                    new XElement("Color",
                        new XElement("Name", color.Name),
                        new XElement("Type", color.Type),
                        new XElement("Value", color.Value)
                    )
                )
            )
        );

        using StreamWriter writer = new StreamWriter(path);
        writer.Write(doc.ToString());
    }
}