#include "color.h"

struct LightingNode
{
    ColorHCL color;
    float intensity;
    long long id;

public:
    LightingNode(ColorHCL color, float intensity);
    LightingNode();

    LightingNode interpolate(LightingNode other, float t);
};