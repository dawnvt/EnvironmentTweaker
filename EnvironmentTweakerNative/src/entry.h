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

struct Nodes
{
    ColorARGB color;
    int lightId;

public:
    Nodes(ColorARGB color, int lightId);
    Nodes();
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
    __declspec(dllexport) void add_light_layer(long long nodeId, int lightId, float time, float length, bool smooth, Interpolation interpolation[], int interpolationLength);
    __declspec(dllexport) long long add_light_node(ColorRGB color, float intensity);
    __declspec(dllexport) int get_light_controller_count();
    __declspec(dllexport) Nodes *get_lighting_node(float time);
    __declspec(dllexport) void clean_nodes(Nodes *nodes);
#ifdef CPLUSPLUS
}
#endif
#endif
#if _MSC_VER
#pragma warning(pop)
#endif