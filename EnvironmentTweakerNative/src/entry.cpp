#include "entry.h"

ColorARGB::ColorARGB(ColorRGB color, float intensity)
{
    this->a = intensity;
    this->r = color.r;
    this->g = color.g;
    this->b = color.b;
}

ColorARGB::ColorARGB()
{
    this->a = 0;
    this->r = 0;
    this->g = 0;
    this->b = 0;
}

LightNodes::LightNodes(ColorARGB color, int lightId)
{
    this->color = color;
    this->lightId = lightId;
}

LightNodes::LightNodes()
{
    this->color = ColorARGB(ColorRGB(0, 0, 0), 0);
    this->lightId = 0;
}

RotationNodes::RotationNodes(Quaternion quaternion, int lightId)
{
    this->lightId = lightId;
    this->quaternion = quaternion;
}

RotationNodes::RotationNodes()
{
    this->quaternion = Quaternion(0, 0, 0, 1);
    this->lightId = 0;
}

void add_light_controller(int lightId)
{
    environmentController.add_light_controller(LightController(lightId));
}

void add_rotation_controller(int lightId)
{
    environmentController.add_rotation_controller(RotationController(lightId));
}

void add_light_layer(long long nodeId, int lightId, float time, float length, bool smooth, Interpolation interpolation[], int interpolationLength)
{
    std::map<float, float> interpolationMap;
    for (int i = 0; i < interpolationLength; i++)
    {
        interpolationMap[interpolation[i].time] = interpolation[i].value;
    }
    environmentController.add_lighting_layer(nodeId, lightId, time, length, smooth, interpolationMap);
}

void add_rotation_layer(long long nodeId, int lightId, float time, float length, bool smooth, Interpolation interpolation[], int interpolationLength)
{
    std::map<float, float> interpolationMap;
    for (int i = 0; i < interpolationLength; i++)
    {
        interpolationMap[interpolation[i].time] = interpolation[i].value;
    }
    environmentController.add_rotation_layer(nodeId, lightId, time, length, smooth, interpolationMap);
}

long long add_light_node(ColorRGB color, float intensity)
{
    return environmentController.add_lighting_node(LightingNode(color.to_hcl(), intensity));
}

long long add_rotation_node(Quaternion quaternion)
{
    return environmentController.add_rotation_node(RotationNode(quaternion));
}

int get_light_controller_count()
{
    return environmentController.get_light_controller_count();
}

int get_rotation_controller_count()
{
    return environmentController.get_rotation_controller_count();
}

LightNodes *get_lighting_node(float time)
{
    auto nodes = environmentController.get_lighting_nodes(time);
    auto nodesArray = new LightNodes[nodes.size()];
    int i = 0;
    for (auto node : nodes)
    {
        nodesArray[i].color = ColorARGB(node.second.color.to_rgb(), node.second.intensity);
        nodesArray[i].lightId = node.first;
        i++;
    }
    return nodesArray;
}

RotationNodes *get_rotation_node(float time)
{
    auto nodes = environmentController.get_rotation_nodes(time);
    auto nodesArray = new RotationNodes[nodes.size()];
    int i = 0;
    for (auto node : nodes)
    {
        nodesArray[i].quaternion = node.second;
        nodesArray[i].lightId = node.first;
        i++;
    }
    return nodesArray;
}

void clean_nodes(LightNodes *lightNodes, RotationNodes *rotationNodes)
{
    delete[] lightNodes;
    delete[] rotationNodes;
}