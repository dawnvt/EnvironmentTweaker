using System.Diagnostics;
using System.Runtime.InteropServices;
using EnvironmentTweakerNative.Structs;

namespace EnvironmentTweakerNative;

internal unsafe partial class Native
{
    private const string DllName = "EnvironmentTweakerNative";

    [DllImport(DllName, EntryPoint = "add_light_controller")]
    internal static extern void AddLightController(int lightId);

    [DllImport(DllName, EntryPoint = "add_light_layer")]
    internal static extern void AddLightLayer(long nodeId, int lightId, float time, float length, [MarshalAs(UnmanagedType.Bool)] bool smooth, Interpolation[] interpolations, int interpolationLength);

    [DllImport(DllName, EntryPoint = "add_light_node")]
    internal static extern long AddLightNode(ColorRGB color, float intensity);

    [DllImport(DllName, EntryPoint = "get_light_controller_count")]
    internal static extern int GetLightControllerCount();

    [DllImport(DllName, EntryPoint = "get_lighting_node")]
    internal static extern LightingNode* GetLightingNode(float time);

    [DllImport(DllName, EntryPoint = "clean_nodes")]
    internal static extern void CleanNodes(LightingNode* lightingNodes, RotationNode* rotationNodes);

    [DllImport(DllName, EntryPoint = "add_rotation_controller")]
    internal static extern void AddRotationController(int lightId);

    [DllImport(DllName, EntryPoint = "add_rotation_layer")]
    internal static extern void AddRotationLayer(long nodeId, int lightId, float time, float length, [MarshalAs(UnmanagedType.Bool)] bool smooth, Interpolation[] interpolations, int interpolationLength);

    [DllImport(DllName, EntryPoint = "add_rotation_node")]
    internal static extern long AddRotationNode(Quaternion quaternion);

    [DllImport(DllName, EntryPoint = "get_rotation_controller_count")]
    internal static extern int GetRotationControllerCount();

    [DllImport(DllName, EntryPoint = "get_rotation_node")]
    internal static extern RotationNode* GetRotationNode(float time);

    [DllImport("kernel32", SetLastError = true)]
    private static extern bool FreeLibrary(nint hModule);

    internal static void UnloadNative()
    {
        foreach (ProcessModule _processModule in Process.GetCurrentProcess().Modules)
        {
            if (_processModule.ModuleName.Contains(DllName))
            {
                FreeLibrary(_processModule.BaseAddress);
            }
        }
    }
}