#include "light_layer.h"
#include <vector>

struct LightController
{
    std::vector<LightLayer *> layers;
    int layerCount;
    int lightId;

public:
    LightController(int lightId);
    LightController();
    ~LightController();

    void add_layer(float time, float length, bool smooth, long long nodeId, std::map<float, float> interpolation);

    LightingNode get_lighting_node(float time, std::vector<LightingNode> lightingNodes);
};