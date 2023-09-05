using EnvironmentTweakerNative;

namespace EnvironmentTweakerConsole;

internal class Program
{
    static void Main(string[] args)
    {
        var color1RGB = new ColorRGB { R = 1.0f, G = 0.0f, B = 1.0f };
        var color2RGB = new ColorRGB { R = 0.0f, G = 1.0f, B = 0.0f };

        var color1HCL = Native.RGBToHCL(color1RGB);
        var color2HCL = Native.RGBToHCL(color2RGB);

        var interpolatedColorRGB = Native.Interpolate(color1RGB, color2RGB, 0.5f);
        var interpolatedColorHCL = Native.Interpolate(color1HCL, color2HCL, 0.5f);

        Console.WriteLine($"Interpolated RGB: {interpolatedColorRGB}");
        Console.WriteLine($"Interpolated HCL: {interpolatedColorHCL}");
        Console.WriteLine($"Original RGB1: {color1RGB}");
        Console.WriteLine($"Original RGB2: {color2RGB}");
        Console.WriteLine($"Original HCL1: {color1HCL}");
        Console.WriteLine($"Original HCL2: {color2HCL}");
    }
}