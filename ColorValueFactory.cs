namespace ColorConvert;

class ColorValueFactory
{
    public ColorValue CreateColorValue(string[] line)
    {
        switch (line[1])
        {
            case "hex":
                return new HexColor(line[0], line[2]);
            case "rgba":
                return new RgbaColor(line[0], line[2]);
            default:
                throw new FormatException("Invalid color type");
        }
    }
}