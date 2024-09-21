namespace ColorConvert.Writers;

class ColorsCsvWriter : IColorsWritable
{
    public ColorsCsvWriter() {}

    public void WriteToFile(string path, List<ColorValue> colors)
    {
        try
        {
            using var writer = new StreamWriter(path);
            foreach (var color in colors)
            {
                var line = $"{color.Name};{color.Type};{color.Value}";
                writer.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey(true);
            Environment.Exit(16);
        }
    }
}