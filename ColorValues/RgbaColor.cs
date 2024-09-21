using System.Text.RegularExpressions;

namespace ColorConvert;

class RgbaColor : ColorValue
{
    public override string Type => "rgba";
    public RgbaColor(string name, string value) : base(name, value)
    {
        ValidateOrThrow(value);
    }

    protected override void ValidateOrThrow(string colorString)
    {
        if (!Regex.IsMatch(colorString, @"^rgba\(((25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9]),){3}(1|0(\.\d{1,2})?)\)$"))
        {
            throw new ArgumentException("Invalid rgba color string");
        }
    }
}