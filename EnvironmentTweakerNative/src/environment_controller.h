#include "structs/light_controller.h"
#include "structs/rotation_controller.h"

class EnvironmentController
{
    std::vector<LightController> lightControllers;
    std::vector<LightingNode> lightingNodes;
    std::vector<RotationController> rotationControllers;
    std::vector<RotationNode> rotationNodes;

public:
    EnvironmentController();
    ~EnvironmentController();

    void add_light_controller(LightController lightController);
    void add_rotation_controller(RotationController rotationController);
    long long add_lighting_node(LightingNode lightingNode);
    long long add_rotation_node(RotationNode rotationNode);
    void add_lighting_layer(long long nodeId, int lightId, float time, float length, bool smooth, std::map<float, float> interpolation);
    void add_rotation_layer(long long nodeId, int lightId, float time, float length, bool smooth, std::map<float, float> interpolation);
    int get_light_controller_count();
    int get_rotation_controller_count();

    std::map<int, LightingNode> get_lighting_nodes(float time);
    std::map<int, Quaternion> get_rotation_nodes(float time);
};