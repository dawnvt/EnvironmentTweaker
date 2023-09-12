#include "rotation_layer.h"

RotationLayer::RotationLayer()
{
    this->interpolation = std::map<float, float>();
    this->length = 0;
    this->nodeId = 0;
    this->smooth = false;
    this->time = 0;
}

RotationLayer::RotationLayer(float time, float length, bool smooth, long long nodeId, std::map<float, float> interpolation)
{
    this->time = time;
    this->length = length;
    this->smooth = smooth;
    this->nodeId = nodeId;
    this->interpolation = interpolation;
}

RotationLayer::~RotationLayer()
{
    this->interpolation.clear();
}