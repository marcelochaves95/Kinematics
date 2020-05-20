#ifndef KINEMATICS_CPP_VECTOR2_H
#define KINEMATICS_CPP_VECTOR2_H

#include <mathf.h>

struct vector2
{
    vector2() {}

    vector2(float xIn, float yIn) : x(xIn), y(yIn) {}

    void setZero() { x = 0.0f; y = 0.0f; }

    void set(float x_, float y_) { x = x_; y = y_; }

    vector2 operator -() const { vector2 v; v.set(-x, -y); return v; }

    float operator () (int32 i) const
    {
        return (&x)[i];
    }

    float& operator () (int32 i)
    {
        return (&x)[i];
    }

    void operator +=(const vector2& v)
    {
        x += v.x; y += v.y;
    }

    void operator -=(const vector2& v)
    {
        x -= v.x; y -= v.y;
    }

    void operator *=(float a)
    {
        x *= a; y *= a;
    }

    float length() const
    {
        return sqrt(x * x + y * y);
    }

    float lengthSquared() const
    {
        return x * x + y * y;
    }

    float normalize()
    {
        float length = length();
        if (length < epsilon)
        {
            return 0.0f;
        }

        float invLength = 1.0f / length;
        x *= invLength;
        y *= invLength;

        return length;
    }

    bool isValid() const
    {
        return isValid(x) && isValid(y);
    }

    vector2 skew() const
    {
        return vector2(-y, x);
    }

    float x, y;
};



#endif //KINEMATICS_CPP_VECTOR2_H
