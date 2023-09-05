#include "lighting_node.h"

LightingNode::LightingNode(ColorHCL color, float intensity)
{
    this->color = color;
    this->intensity = intensity;
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
        other.intensity + t * (other.intensity - this->intensity));
}