using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtils
{
    public static Vector2 ToVector2(this Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.z);
    }

    public static Vector3 ToVector3(this Vector2 vector2)
    {
        return new Vector3(vector2.x, 0f, vector2.y);
    }

    public static Vector3 IgnoreY(this Vector3 vector3)
    {
        vector3.y = 0f;
        return vector3;
    }
}
