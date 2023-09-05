using System.Runtime.InteropServices;

namespace EnvironmentTweakerNative.Structs;

[StructLayout(LayoutKind.Sequential)]
struct LightingNode
{
    ColorHCL color;
    float intensity;
}