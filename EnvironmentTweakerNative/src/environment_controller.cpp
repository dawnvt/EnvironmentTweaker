#include "environment_controller.h"
#include "overloads/linq.h"
#include <stdexcept>

EnvironmentController::EnvironmentController()
{
    this->lightControllers = std::vector<LightController>();
    this->lightingNodes = std::vector<LightingNode>();
};

EnvironmentController::~EnvironmentController()
{
    this->lightControllers.clear();
    this->lightingNodes.clear();
};

void EnvironmentController::add_light_controller(LightController lightController)
{
    this->lightControllers.push_back(lightController);
};

int EnvironmentController::add_lighting_node(LightingNode lightingNode)
{
    lightingNode.id = this->lightingNodes.size() + 1;
    this->lightingNodes.push_back(lightingNode);
    return lightingNode.id;
};

void EnvironmentController::add_lighting_layer(long long nodeId, int lightId, float time, float length, bool smooth, std::map<float, float> interpolation)
{
    auto lightNode = find_item(this->lightingNodes, [nodeId](const LightingNode lightingNode)
                               { return lightingNode.id == nodeId; });
    if (lightNode->id != 0)
    {
        auto lightController = find_item(this->lightControllers, [lightId](const LightController lightController)
                                         { return lightController.lightId == lightId; });
        if (lightController->lightId != 0)
        {
            lightController->add_layer(time, length, smooth, nodeId, interpolation);
        }
        else
        {
            throw std::invalid_argument("LightController not found");
        }
    }
    else
    {
        throw std::invalid_argument("LightingNode not found");
    }
};

std::map<int, LightingNode> EnvironmentController::get_lighting_nodes(float time)
{
    auto length = this->lightControllers.size();
    std::map<int, LightingNode> lightingNodes;
    for (int i = 0; i < length; i++)
    {
        lightingNodes[this->lightControllers[i].lightId] = this->lightControllers[i].get_lighting_node(time, this->lightingNodes);
    }
    return lightingNodes;
};

int EnvironmentController::get_light_controller_count()
{
    return this->lightControllers.size();
};