struct Quaternion
{
    float x;
    float y;
    float z;
    float w;

public:
    Quaternion(float x, float y, float z, float w);

    Quaternion interpolate(Quaternion other, float t);
};