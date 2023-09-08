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

Nodes::Nodes(ColorARGB color, int lightId)
{
    this->color = color;
    this->lightId = lightId;
}

Nodes::Nodes()
{
    this->color = ColorARGB(ColorRGB(0, 0, 0), 0);
    this->lightId = 0;
}

void add_light_controller(int lightId)
{
    environmentController.add_light_controller(LightController(lightId));
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

long long add_light_node(ColorRGB color, float intensity)
{
    return environmentController.add_lighting_node(LightingNode(color.to_hcl(), intensity));
}

int get_light_controller_count()
{
    return environmentController.get_light_controller_count();
}

Nodes *get_lighting_node(float time)
{
    auto nodes = environmentController.get_lighting_nodes(time);
    auto nodesArray = new Nodes[nodes.size()];
    int i = 0;
    for (auto node : nodes)
    {
        nodesArray[i].color = ColorARGB(node.second.color.to_rgb(), node.second.intensity);
        nodesArray[i].lightId = node.first;
        i++;
    }
    return nodesArray;
}

void clean_nodes(Nodes *nodes)
{
    delete[] nodes;
}