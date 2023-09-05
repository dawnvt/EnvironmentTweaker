using System.Runtime.InteropServices;

namespace EnvironmentTweakerNative.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct Quaternion
{
    public float X;
    public float Y;
    public float Z;
    public float W;

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}, Z: {Z}, W: {W}";
    }
}