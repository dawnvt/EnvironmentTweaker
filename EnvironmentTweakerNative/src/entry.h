#ifndef ENTRY_H
#define ENTRY_H
#include <cstdio>
#include "environment_controller.h"

static EnvironmentController environmentController;

struct Interpolation
{
    float time;
    float value;
};

struct ColorARGB
{
    float a;
    float r;
    float g;
    float b;

public:
    ColorARGB(ColorRGB color, float intensity);
    ColorARGB();
};

struct LightNodes
{
    ColorARGB color;
    int lightId;

public:
    LightNodes(ColorARGB color, int lightId);
    LightNodes();
};

struct RotationNodes
{
    Quaternion quaternion;
    int lightId;

public:
    RotationNodes(Quaternion quaternion, int lightId);
    RotationNodes();
};

#if _MSC_VER
#pragma warning(push)
#pragma warning(disable : 4190)
#endif
#ifdef CPLUSPLUS
extern "C"
{
#endif
    __declspec(dllexport) void add_light_controller(int lightId);
    __declspec(dllexport) void add_rotation_controller(int lightId);
    __declspec(dllexport) void add_light_layer(long long nodeId, int lightId, float time, float length, bool smooth, Interpolation interpolation[], int interpolationLength);
    __declspec(dllexport) void add_rotation_layer(long long nodeId, int lightId, float time, float length, bool smooth, Interpolation interpolation[], int interpolationLength);
    __declspec(dllexport) long long add_light_node(ColorRGB color, float intensity);
    __declspec(dllexport) long long add_rotation_node(Quaternion quaternion);
    __declspec(dllexport) int get_light_controller_count();
    __declspec(dllexport) int get_rotation_controller_count();
    __declspec(dllexport) LightNodes *get_lighting_node(float time);
    __declspec(dllexport) RotationNodes *get_rotation_node(float time);
    __declspec(dllexport) void clean_nodes(LightNodes *lightNodes, RotationNodes *rotationNodes);
#ifdef CPLUSPLUS
}
#endif
#endif
#if _MSC_VER
#pragma warning(pop)
#endif