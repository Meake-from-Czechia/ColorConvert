namespace ColorConvert.Readers;

class ColorsCsvReader : IColorsReadable
{
    public ColorsCsvReader()
    {
        // Why define empty constructor explicitly (according to the diagram)?
    }

    public List<ColorValue> ReadColors(string path)
    {
        List<ColorValue> colors = new List<ColorValue>();
        var factory = new ColorValueFactory();
        try
        {
            using var reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(';');
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