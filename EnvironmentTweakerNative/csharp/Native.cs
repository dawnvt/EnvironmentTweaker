using System.Runtime.InteropServices;

namespace EnvironmentTweakerNative;

internal partial class Native
{
    private const string DllName = "EnvironmentTweakerNative";

    [LibraryImport(DllName, EntryPoint = "hello_func")]
    internal static partial void HelloFunc();

    [LibraryImport(DllName, EntryPoint = "hcl_to_rgb")]
    internal static partial ColorRGB HCLToRGB(ColorHCL color);

    [LibraryImport(DllName, EntryPoint = "rgb_to_hcl")]
    internal static partial ColorHCL RGBToHCL(ColorRGB color);

    [LibraryImport(DllName, EntryPoint = "interpolate_rgb")]
    internal static partial ColorRGB Interpolate(ColorRGB color1, ColorRGB color2, float t);

    [LibraryImport(DllName, EntryPoint = "interpolate_hcl")]
    internal static partial ColorHCL Interpolate(ColorHCL color1, ColorHCL color2, float t);
}