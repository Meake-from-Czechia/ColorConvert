namespace ColorConvert;

internal interface IColorsWritable
{
    public void WriteToFile(string path, List<ColorValue> colors);
}