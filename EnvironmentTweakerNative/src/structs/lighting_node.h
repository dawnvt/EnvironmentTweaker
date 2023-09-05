#include "color.h"

struct LightingNode
{
    ColorHCL color;
    float intensity;

public:
    LightingNode(ColorHCL color, float intensity);
    LightingNode();

    LightingNode interpolate(LightingNode other, float t);
};