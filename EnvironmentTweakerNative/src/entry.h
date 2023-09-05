#ifndef ENTRY_H
#define ENTRY_H
#include <cstdio>
#include "color.h"

#ifdef CPLUSPLUS
extern "C"
{
#endif

    __declspec(dllexport) void hello_func();
    __declspec(dllexport) ColorRGB interpolate_rgb(ColorRGB a, ColorRGB b, float t);
    __declspec(dllexport) ColorHCL interpolate_hcl(ColorHCL a, ColorHCL b, float t);
    __declspec(dllexport) ColorRGB hcl_to_rgb(ColorHCL hcl);
    __declspec(dllexport) ColorHCL rgb_to_hcl(ColorRGB rgb);
#ifdef CPLUSPLUS
}
#endif
#endif