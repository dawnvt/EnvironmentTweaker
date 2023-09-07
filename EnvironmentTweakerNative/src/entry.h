#ifndef ENTRY_H
#define ENTRY_H
#include <cstdio>
#include "environment_controller.h"

static EnvironmentController environmentController;

struct interpolation
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
};

struct Nodes
{
    ColorARGB color;
    int lightId;
};

#if _MSC_VER
#pragma warning(push)
#pragma warning(disable : 4190)
#endif
#ifdef CPLUSPLUS
extern "C"
{
#endif
    void add_light_controller(int lightId);
    void add_light_layer(long long nodeId, int lightId, float time, float length, bool smooth, interpolation interpolation[]);
    long long add_light_node(ColorRGB color, float intensity);
    int get_light_controller_count();
    Nodes *get_lighting_node(float time);
#ifdef CPLUSPLUS
}
#endif
#endif
#if _MSC_VER
#pragma warning(pop)
#endif