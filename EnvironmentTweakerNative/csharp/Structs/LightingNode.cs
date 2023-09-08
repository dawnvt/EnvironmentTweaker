using System.Runtime.InteropServices;

namespace EnvironmentTweakerNative.Structs;

[StructLayout(LayoutKind.Sequential)]
struct LightingNode
{
    public ColorARGB color;
    public int lightId;
}

[StructLayout(LayoutKind.Sequential)]
struct Interpolation
{
    float time;
    float value;

    public Interpolation(float time, float value)
    {
        this.time = time;
        this.value = value;
    }
}