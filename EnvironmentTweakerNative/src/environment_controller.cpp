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

long long EnvironmentController::add_lighting_node(LightingNode lightingNode)
{
    lightingNode.id = this->lightingNodes.size() + 1;
    this->lightingNodes.push_back(lightingNode);
    return lightingNode.id;
};

void EnvironmentController::add_rotation_controller(RotationController rotationController)
{
    this->rotationControllers.push_back(rotationController);
};

long long EnvironmentController::add_rotation_node(RotationNode rotationNode)
{
    rotationNode.id = this->rotationNodes.size() + 1;
    this->rotationNodes.push_back(rotationNode);
    return rotationNode.id;
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

void EnvironmentController::add_rotation_layer(long long nodeId, int lightId, float time, float length, bool smooth, std::map<float, float> interpolation)
{
    auto rotationNode = find_item(this->rotationNodes, [nodeId](const RotationNode rotationNode)
                                  { return rotationNode.id == nodeId; });
    if (rotationNode->id != 0)
    {
        auto rotationController = find_item(this->rotationControllers, [lightId](const RotationController rotationController)
                                            { return rotationController.lightId == lightId; });
        if (rotationController->lightId != 0)
        {
            rotationController->add_layer(time, length, smooth, nodeId, interpolation);
        }
        else
        {
            throw std::invalid_argument("RotationController not found");
        }
    }
    else
    {
        throw std::invalid_argument("RotationNode not found");
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

int EnvironmentController::get_rotation_controller_count()
{
    return this->rotationControllers.size();
};

std::map<int, Quaternion> EnvironmentController::get_rotation_nodes(float time)
{
    auto length = this->rotationControllers.size();
    std::map<int, Quaternion> rotationNodes;
    for (int i = 0; i < length; i++)
    {
        rotationNodes[this->rotationControllers[i].lightId] = this->rotationControllers[i].get_rotation_node(time, this->rotationNodes);
    }
    return rotationNodes;
}