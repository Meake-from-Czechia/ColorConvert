using System.Text.RegularExpressions;

namespace ColorConvert;

class HexColor : ColorValue
{
    public override string Type => "hex";
    public HexColor(string name, string value) : base(name, value)
    {
        ValidateOrThrow(value);
    }
    protected override void ValidateOrThrow(string colorString)
    {
        if (!Regex.IsMatch(colorString, @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$"))
        {
            throw new ArgumentException("Invalid hex color string");
        }
    }
}