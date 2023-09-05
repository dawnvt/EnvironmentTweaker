using System.Runtime.InteropServices;

namespace EnvironmentTweakerNative.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct ColorHCL
{
    public float H;
    public float C;
    public float L;

    public override string ToString()
    {
        return $"H: {H}, C: {C}, L: {L}";
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct ColorRGB
{
    public float R;
    public float G;
    public float B;

    public override string ToString()
    {
        return $"R: {R}, G: {G}, B: {B}";
    }
}