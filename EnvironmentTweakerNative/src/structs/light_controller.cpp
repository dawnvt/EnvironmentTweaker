#include "light_controller.h"
#include "../overloads/linq.h"

LightController::LightController(int lightId)
{
    this->layerCount = 0;
    this->lightId = lightId;
    this->layers = std::vector<LightLayer>();
}

LightController::~LightController()
{
    this->layers.clear();
    this->layerCount = 0;
}

void LightController::add_layer(float time, float length, bool smooth, LightingNode *lightingNode, std::map<float, float> interpolation)
{
    this->layers.push_back(LightLayer(time, length, smooth, lightingNode, interpolation));
    this->layerCount++;
}

LightingNode LightController::get_lighting_node(float time)
{
    auto layers = find_items(this->layers, [time](const LightLayer &layer)
                             { return layer.time <= time && layer.time + layer.length >= time; });
    LightingNode lightingNode = LightingNode();
    auto it = layers.begin();
    while (it != layers.end())
    {
        if (it->smooth)
        {
            auto intIt = it->interpolation.begin();
            float t = 0;
            auto nodeTime = time - it->time;
            while (intIt != it->interpolation.end())
            {
                if (intIt->first > nodeTime)
                {
                    t = intIt->second;
                    break;
                }
                intIt++;
            }
            intIt++;
            t = t + (it->length - nodeTime) * (intIt->second - t);
            lightingNode = lightingNode.interpolate(*it->lightingNode, t);
        }
        else
            lightingNode = *it->lightingNode;

        it++;
    }
    return lightingNode;
}
