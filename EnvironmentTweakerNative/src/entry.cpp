#include "entry.h"

void add_light_controller(int lightId)
{
    environmentController.add_light_controller(LightController(lightId));
}

void add_light_layer(long long nodeId, int lightId, float time, float length, bool smooth, interpolation interpolation[])
{
    std::map<float, float> interpolationMap;
    for (int i = 0; i < sizeof(interpolation) / sizeof(interpolation[0]); i++)
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
}