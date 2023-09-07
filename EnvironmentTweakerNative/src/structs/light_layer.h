#include "lighting_node.h"
#include <map>

struct LightLayer
{
    float time;
    float length;
    LightingNode *lightingNode;
    bool smooth;
    std::map<float, float> interpolation;

public:
    LightLayer(float time, float length, bool smooth, LightingNode *lightingNode, std::map<float, float> interpolation);
    ~LightLayer();
};
