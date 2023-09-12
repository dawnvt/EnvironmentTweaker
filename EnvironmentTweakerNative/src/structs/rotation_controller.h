#include "rotation_layer.h"
#include <vector>

struct RotationController
{
    std::vector<RotationLayer *> layers;
    int layerCount;
    int lightId;

public:
    RotationController(int lightId);
    RotationController();
    ~RotationController();

    void add_layer(float time, float length, bool smooth, long long nodeId, std::map<float, float> interpolation);

    Quaternion get_rotation_node(float time, std::vector<RotationNode> rotationNodes);
};