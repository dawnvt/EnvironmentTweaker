#include "rotation_node.h"
#include <map>

struct RotationLayer
{
    float time;
    float length;
    long long nodeId;
    bool smooth;
    std::map<float, float> interpolation;

public:
    RotationLayer(float time, float length, bool smooth, long long nodeId, std::map<float, float> interpolation);
    RotationLayer();
    ~RotationLayer();
};
