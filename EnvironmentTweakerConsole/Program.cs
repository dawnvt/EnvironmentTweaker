using System.Text;
using EnvironmentTweakerNative;
using EnvironmentTweakerNative.Structs;

namespace EnvironmentTweakerConsole;

internal class Program
{
    static unsafe void Main(string[] args)
    {
        Native.AddLightController(1);
        Native.AddRotationController(1);
        var _lightNode1 = Native.AddLightNode(new ColorRGB { R = 1, G = 1, B = 1 }, .75f);
        var _lightNode2 = Native.AddLightNode(new ColorRGB { R = 0, G = 1, B = 0 }, .5f);
        var _rotationNode1 = Native.AddRotationNode(new Quaternion { X = 0.7071068f, Y = 0, Z = 0, W = 0.7071068f });
        var _rotationNode2 = Native.AddRotationNode(new Quaternion { X = 0, Y = 0.7071068f, Z = 0, W = 0.7071068f });
        Native.AddLightLayer(_lightNode1, 1, 0, 4, true, new[] { new Interpolation(0, 0), new Interpolation(0.25f, 1) }, 2);
        Native.AddLightLayer(_lightNode2, 1, 0, 4, true, new[] { new Interpolation(0, 0), new Interpolation(1, 1) }, 2);
        Native.AddRotationLayer(_rotationNode1, 1, 0, 4, true, new[] { new Interpolation(0, 0), new Interpolation(0.25f, 1) }, 2);
        Native.AddRotationLayer(_rotationNode2, 1, 0, 4, true, new[] { new Interpolation(0, 0), new Interpolation(1, 1) }, 2);
        var _lightControllerCount = Native.GetLightControllerCount();
        var _rotationControllerCount = Native.GetRotationControllerCount();
        Console.WriteLine($"Light Count: {_lightControllerCount}, Rotation Count: {_rotationControllerCount}");
        const float delta = 1 / 60f;
        var sb = new StringBuilder();
        for (var i = 0; i < 60 * 4; i++)
        {
            var _lightingNode = Native.GetLightingNode(i * delta);
            var _rotationNode = Native.GetRotationNode(i * delta);
            sb.Clear();
            sb.AppendLine($"Time: {i * delta}");
            for (var j = 0; j < _lightControllerCount; j++)
            {
                sb.AppendLine($"\tColor: {_lightingNode->Color}, LightId: {_lightingNode->LightId}");
                _lightingNode++;
            }

            for (var j = 0; j < _rotationControllerCount; j++)
            {
                sb.AppendLine($"\tRotation: {_rotationNode->Quaternion}, LightId: {_rotationNode->LightId}");
                _rotationNode++;
            }

            Console.WriteLine(sb.ToString());
            Native.CleanNodes(_lightingNode - _lightControllerCount, _rotationNode - _rotationControllerCount);
        }
        Native.UnloadNative();
    }
}