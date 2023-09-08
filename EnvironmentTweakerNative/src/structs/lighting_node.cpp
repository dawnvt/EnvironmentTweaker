#include "lighting_node.h"
#include <cmath>

LightingNode::LightingNode(ColorHCL color, float intensity)
{
    const double pow = std::pow(10, 4);
    this->color = color;
    this->intensity = static_cast<int>(intensity * pow) / pow;
}

LightingNode::LightingNode()
{
    this->color = ColorHCL();
    this->intensity = 0;
}

LightingNode LightingNode::interpolate(LightingNode other, float t)
{
    return LightingNode(
        this->color.interpolate(other.color, t),
        this->intensity + t * (other.intensity - this->intensity));
}