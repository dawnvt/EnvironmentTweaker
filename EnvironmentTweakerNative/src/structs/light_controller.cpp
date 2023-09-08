#include "light_controller.h"
#include "../overloads/linq.h"

LightController::LightController(int lightId)
{
    this->layerCount = 0;
    this->lightId = lightId;
    this->layers = std::vector<LightLayer *>();
}
LightController::LightController()
{
    this->layerCount = 0;
    this->lightId = 0;
    this->layers = std::vector<LightLayer *>();
}

LightController::~LightController()
{
    for (auto layer : this->layers)
    {
        delete layer;
    }
    this->layers.clear();
    this->layerCount = 0;
}

void LightController::add_layer(float time, float length, bool smooth, long long nodeId, std::map<float, float> interpolation)
{
    this->layers.push_back(new LightLayer(time, length, smooth, nodeId, interpolation));
    this->layerCount++;
}

LightingNode LightController::get_lighting_node(float time, std::vector<LightingNode> lightingNodes)
{
    auto layers = find_items(this->layers, [time](const LightLayer *layer)
                             { return layer->time <= time && layer->time + layer->length >= time; });
    LightingNode lightingNode = LightingNode();
    int length = layers.size();
    for (int i = 0; i < length; i++)
    {
        auto layer = layers[i];
        if (layer->smooth)
        {
            float t1 = 0, t2 = 0;
            auto nodeTime = (time - layer->time) / layer->length;
            for (auto inter : layer->interpolation)
            {
                if (inter.first <= nodeTime)
                {
                    t1 = inter.second;
                }
            }
            auto intIt = layer->interpolation.begin();
            while (intIt != layer->interpolation.end())
            {
                if (intIt->first == t1)
                {
                    intIt++;
                    t2 = intIt->second;
                    break;
                }
                intIt++;
            }
            float t = t1 + nodeTime * (t2 - t1);
            auto lightNode = *find_item(lightingNodes, [layer](const LightingNode lightingNode)
                                        { return lightingNode.id == layer->nodeId; });
            lightingNode = lightingNode.interpolate(lightNode, t);
        }
        else
        {
            lightingNode = *find_item(lightingNodes, [layer](const LightingNode lightingNode)
                                      { return lightingNode.id == layer->nodeId; });
        }
    }
    return lightingNode;
}
