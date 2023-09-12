using System.Runtime.InteropServices;

namespace EnvironmentTweakerNative.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct LightingNode
{
    public ColorARGB Color;
    public int LightId;
}

[StructLayout(LayoutKind.Sequential)]
public struct RotationNode
{
    public Quaternion Quaternion;
    public int LightId;
}

[StructLayout(LayoutKind.Sequential)]
public struct Interpolation
{
    public float Time;
    public float Value;

    public Interpolation(float time, float value)
    {
        Time = time;
        Value = value;
    }
}