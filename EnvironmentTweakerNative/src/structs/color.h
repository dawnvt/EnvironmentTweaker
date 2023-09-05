struct ColorRGB;

struct ColorHCL
{
    float h; // 0-360
    float c; // 0-1
    float l; // 0-1

public:
    ColorHCL(float h, float c, float l);
    ColorHCL();

    ColorRGB to_rgb();

    ColorHCL interpolate(ColorHCL other, float t);
};

struct ColorRGB
{
    float r; // 0-1
    float g; // 0-1
    float b; // 0-1

public:
    ColorRGB(float r, float g, float b);
    ColorRGB();

    ColorHCL to_hcl();
};