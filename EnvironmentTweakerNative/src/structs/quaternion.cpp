#include "quaternion.h"
#include <cmath>

Quaternion::Quaternion(float x, float y, float z, float w)
{
    this->x = x;
    this->y = y;
    this->z = z;
    this->w = w;
}

Quaternion::Quaternion()
{
    this->w = 1;
    this->x = 0;
    this->y = 0;
    this->z = 0;
}

Quaternion Quaternion::interpolate(Quaternion other, float t)
{
    float w1 = this->w, x1 = this->x, y1 = this->y, z1 = this->z;
    float w2 = other.w, x2 = other.x, y2 = other.y, z2 = other.z;

    float dot = w1 * w2 + x1 * x2 + y1 * y2 + z1 * z2;

    if (dot < 0)
    {
        w1 = -w1;
        x1 = -x1;
        y1 = -y1;
        z1 = -z1;

        dot = -dot;
    }

    float k0, k1;

    if (dot > 0.9995f)
    {
        k0 = 1 - t;
        k1 = t;
    }
    else
    {
        const float theta = std::acos(dot);
        const float invSinTheta = 1 / std::sin(theta);

        k0 = std::sin((1 - t) * theta) * invSinTheta;
        k1 = std::sin(t * theta) * invSinTheta;
    }

    return Quaternion(
        w1 * k0 + w2 * k1,
        x1 * k0 + x2 * k1,
        y1 * k0 + y2 * k1,
        z1 * k0 + z2 * k1);
}