#include "lighting_node.h"
#include <map>

struct LightLayer
{
    float time;
    float length;
    long long nodeId;
    bool smooth;
    std::map<float, float> interpolation;

public:
    LightLayer(float time, float length, bool smooth, long long nodeId, std::map<float, float> interpolation);
    LightLayer();
    ~LightLayer();
};
