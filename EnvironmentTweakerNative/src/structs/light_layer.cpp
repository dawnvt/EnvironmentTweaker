#include "light_layer.h"

LightLayer::LightLayer(float time, float length, bool smooth, long long nodeId, std::map<float, float> interpolation)
{
    this->time = time;
    this->length = length;
    this->nodeId = nodeId;
    this->smooth = smooth;
    this->interpolation = interpolation;
}

LightLayer::LightLayer()
{
    this->time = 0;
    this->length = 0;
    this->nodeId = 0;
    this->smooth = false;
    this->interpolation = std::map<float, float>();
}

LightLayer::~LightLayer()
{
    this->interpolation.clear();
}