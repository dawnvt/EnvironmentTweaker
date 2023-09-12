#include "rotation_controller.h"
#include "../overloads/linq.h"

RotationController::RotationController(int lightId)
{
    this->layers = std::vector<RotationLayer *>();
    this->layerCount = 0;
    this->lightId = lightId;
}

RotationController::RotationController()
{
    this->layers = std::vector<RotationLayer *>();
    this->layerCount = 0;
    this->lightId = 0;
}

RotationController::~RotationController()
{
    for (int i = 0; i < this->layerCount; i++)
    {
        delete this->layers[i];
    }
    this->layers.clear();
}

void RotationController::add_layer(float time, float length, bool smooth, long long nodeId, std::map<float, float> interpolation)
{
    this->layers.push_back(new RotationLayer(time, length, smooth, nodeId, interpolation));
    this->layerCount++;
}

Quaternion RotationController::get_rotation_node(float time, std::vector<RotationNode> rotationNodes)
{
    auto layers = find_items(this->layers, [time](const RotationLayer *layer)
                             { return layer->time <= time && layer->time + layer->length >= time; });
    Quaternion node = Quaternion(0, 0, 0, 1);
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
            auto rotationNode = *find_item(rotationNodes, [layer](const RotationNode lightingNode)
                                           { return lightingNode.id == layer->nodeId; });
            node = node.interpolate(rotationNode.quaternion, t);
        }
        else
        {
            node = (*find_item(rotationNodes, [layer](const RotationNode lightingNode)
                               { return lightingNode.id == layer->nodeId; }))
                       .quaternion;
        }
    }
    return node;
}