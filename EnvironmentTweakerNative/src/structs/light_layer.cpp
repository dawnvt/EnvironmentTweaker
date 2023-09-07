#include "light_layer.h"

LightLayer::LightLayer(float time, float length, bool smooth, LightingNode *lightingNode, std::map<float, float> interpolation)
{
    this->time = time;
    this->length = length;
    this->lightingNode = lightingNode;
    this->smooth = smooth;
    this->interpolation = interpolation;
}

LightLayer::~LightLayer()
{
    delete this->lightingNode;
    this->interpolation.clear();
}