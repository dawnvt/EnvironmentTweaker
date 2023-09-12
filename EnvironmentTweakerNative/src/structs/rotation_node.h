#include "quaternion.h"

struct RotationNode
{
    Quaternion quaternion;
    long long id;

public:
    RotationNode(Quaternion quaternion);
    RotationNode();

    Quaternion interpolate(RotationNode other, float t);
};