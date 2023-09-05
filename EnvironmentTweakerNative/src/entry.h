#ifndef ENTRY_H
#define ENTRY_H
#include <cstdio>
#include "structs/color.h"

#if _MSC_VER
#pragma warning(push)
#pragma warning(disable : 4190)
#endif
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
#if _MSC_VER
#pragma warning(pop)
#endif