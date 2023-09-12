#include "rotation_node.h"

Quaternion RotationNode::interpolate(RotationNode other, float t)
{
    return this->quaternion.interpolate(other.quaternion, t);
}

RotationNode::RotationNode(Quaternion quaternion)
{
    this->quaternion = quaternion;
}

RotationNode::RotationNode()
{
    this->quaternion = Quaternion(0, 0, 0, 1);
}