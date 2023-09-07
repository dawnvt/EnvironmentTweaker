#include "structs/light_controller.h"

class EnvironmentController
{
    std::vector<LightController> lightControllers;
    std::vector<LightingNode> lightingNodes;

public:
    EnvironmentController();
    ~EnvironmentController();

    void add_light_controller(LightController lightController);
    int add_lighting_node(LightingNode lightingNode);
    void add_lighting_layer(long long nodeId, int lightId, float time, float length, bool smooth, std::map<float, float> interpolation);
    int get_light_controller_count();

    std::map<int, LightingNode> get_lighting_nodes(float time);
};