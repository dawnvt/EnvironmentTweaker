#include "color.h"
#include <cmath>
#include <algorithm>

ColorHCL::ColorHCL(float h, float c, float l)
{
    while (h < 0)
    {
        h += 360;
    }
    while (h > 360)
    {
        h = static_cast<int>(h) % 360;
    }
    this->h = h;
    this->c = c;
    this->l = l;
}

ColorHCL::ColorHCL()
{
    this->h = 0;
    this->c = 0;
    this->l = 0;
}

ColorRGB::ColorRGB(float r, float g, float b)
{
    const double pow = std::pow(10, 4);
    this->r = static_cast<int>(r * pow) / pow;
    this->g = static_cast<int>(g * pow) / pow;
    this->b = static_cast<int>(b * pow) / pow;
}

ColorRGB::ColorRGB()
{
    this->r = 0;
    this->g = 0;
    this->b = 0;
}

ColorRGB ColorHCL::to_rgb()
{
    float h = this->h / 360.0f;
    float c = this->c;
    float l = this->l;

    float x = c * (1 - std::abs(std::fmod(h * 6, 2) - 1));
    float m = l - c / 2;

    float r, g, b;

    if (h < 1.0f / 6)
    {
        r = c;
        g = x;
        b = 0;
    }
    else if (h < 2.0f / 6)
    {
        r = x;
        g = c;
        b = 0;
    }
    else if (h < 3.0f / 6)
    {
        r = 0;
        g = c;
        b = x;
    }
    else if (h < 4.0f / 6)
    {
        r = 0;
        g = x;
        b = c;
    }
    else if (h < 5.0f / 6)
    {
        r = x;
        g = 0;
        b = c;
    }
    else
    {
        r = c;
        g = 0;
        b = x;
    }

    return ColorRGB(r + m, g + m, b + m);
}

ColorHCL ColorHCL::interpolate(ColorHCL other, float t)
{
    const float h0 = this->h, h1 = other.h, c0 = this->c, c1 = other.c, l0 = this->l, l1 = other.l;
    float dh;

    if (h1 > h0 && h1 - h0 > 180)
    {
        dh = h1 - (h0 + 360);
    }
    else if (h1 < h0 && h0 - h1 > 180)
    {
        dh = h1 + 360 - h0;
    }
    else
    {
        dh = h1 - h0;
    }

    const float h = h0 + t * dh, c = c0 + t * (c1 - c0), l = l0 + t * (l1 - l0);

    return ColorHCL{h, c, l};
}

ColorHCL ColorRGB::to_hcl()
{
    float r = this->r;
    float g = this->g;
    float b = this->b;

    float max = std::max(r, std::max(g, b));
    float min = std::min(r, std::min(g, b));

    float c = max - min;
    float l = (max + min) / 2;

    float h;

    if (c == 0)
    {
        h = 0;
    }
    else if (max == r)
    {
        h = std::fmod((g - b) / c, 6);
    }
    else if (max == g)
    {
        h = (b - r) / c + 2;
    }
    else
    {
        h = (r - g) / c + 4;
    }

    return ColorHCL{h * 60, c, l};
}