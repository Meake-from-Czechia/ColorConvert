namespace ColorConvert;

internal interface IColorsReadable
{
    public List<ColorValue> ReadColors(string path);
}