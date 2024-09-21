using ColorConvert.Writers;
using ColorConvert.Readers;

namespace ColorConvert;

class Program
{
    static void Main()
    {
        string inputPath = "Input\\colors.xml"; // Change me
        string outputPath = "Output\\colors.json"; // Change me
        
        // Automatically selects the correct reader based on the file extension
        IColorsReadable reader = (inputPath.EndsWith(".csv"))
            ? new ColorsCsvReader()
            : (inputPath.EndsWith(".json") ? new ColorsJsonReader() : new ColorsXmlReader());
        // Automatically selects the correct writer based on the file extension
        IColorsWritable writer = (outputPath.EndsWith(".csv"))
            ? new ColorsCsvWriter()
            : (outputPath.EndsWith(".json") ? new ColorsJsonWriter() : new ColorsXmlWriter());
        var colors = reader.ReadColors(inputPath);
        // Presumes that the output directory exists and outputPath is in format "dir\\file.ext"
        string outputDir = outputPath.Split("\\")[0];
        if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
        writer.WriteToFile(outputPath, colors);
    }
}