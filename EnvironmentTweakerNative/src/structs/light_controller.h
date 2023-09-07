#include "light_layer.h"
#include <vector>

class LightController
{
    std::vector<LightLayer> layers;
    int layerCount;
    int lightId;

public:
    LightController();
    ~LightController();

    void add_layer(float time, float length, bool smooth, LightingNode *lightingNode, std::map<float, float> interpolation);

    LightingNode get_lighting_node(float time);
};