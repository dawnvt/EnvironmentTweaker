#include "entry.h"

void hello_func()
{
    printf("Hello from C++!\n");
}

ColorHCL interpolate_hcl(ColorHCL a, ColorHCL b, float t)
{
    return a.interpolate(b, t);
}

ColorRGB interpolate_rgb(ColorRGB a, ColorRGB b, float t)
{
    return a.to_hcl().interpolate(b.to_hcl(), t).to_rgb();
}

ColorRGB hcl_to_rgb(ColorHCL hcl)
{
    return hcl.to_rgb();
}

ColorHCL rgb_to_hcl(ColorRGB rgb)
{
    return rgb.to_hcl();
}