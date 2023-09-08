using EnvironmentTweakerNative;
using EnvironmentTweakerNative.Structs;

namespace EnvironmentTweakerConsole;

internal class Program
{
    static unsafe void Main(string[] args)
    {
        Native.AddLightController(1);
        var id = Native.AddLightNode(new ColorRGB { R = 1, G = 1, B = 1 }, .75f);
        var id2 = Native.AddLightNode(new ColorRGB { R = 0, G = 1, B = 0 }, .5f);
        Native.AddLightLayer(id, 1, 0, 4, true, new[] { new Interpolation(0, 0), new Interpolation(0.25f, 1) }, 2);
        Native.AddLightLayer(id2, 1, 0, 4, true, new[] { new Interpolation(0, 0), new Interpolation(1, 1) }, 2);
        var count = Native.GetLightControllerCount();
        Console.WriteLine($"Count: {count}");
        var delta = 1 / 60f;
        for (var i = 0; i < 60 * 4; i++)
        {
            var nodes = Native.GetLightingNode(i * delta);
            for (var j = 0; j < count; j++)
            {
                Console.WriteLine($"Time: {i * delta}, Color: {nodes->color}, LightId: {nodes->lightId}");
                nodes++;
            }
            Native.CleanNodes(nodes - count);
        }
    }
}