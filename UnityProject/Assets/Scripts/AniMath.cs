using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AniMath
{
    public static float Lerp(float a, float b, float p, bool allowExtrap = true)
    {
        if (!allowExtrap)
        {
            if (p > 1) p = 1;
            if (p < 0) p = 0;
        }
        return (b - a) * p + a;
    }

    public static Quaternion Lerp(Quaternion a, Quaternion b, float p, bool allowExtrap = false)
    {
        Quaternion rot = Quaternion.identity;

        rot.x = Lerp(a.x, b.x, p, allowExtrap);
        rot.y = Lerp(a.y, b.y, p, allowExtrap);
        rot.z = Lerp(a.z, b.z, p, allowExtrap);
        rot.w = Lerp(a.w, b.w, p, allowExtrap);

        return rot;

    }

    public static Vector3 Lerp(Vector3 a, Vector3 b, float p, bool allowExtrap = true)
    {
        if (!allowExtrap)
        {
            if (p > 1) p = 1;
            if (p < 0) p = 0;  
        }

        return (b - a) * p + a;
    }

    public static float Map(float v, float minin, float maxin, float minout, float maxout)
    {
        float p = (v - minin) / (maxin - minin);

        return Lerp(minout, maxout, p);
    }

    public static float Ease(float current, float target, float percentAfter1Sec, float dt)
    {
        float p = 1 - Mathf.Pow(percentAfter1Sec, dt);

        return Lerp(current, target, p);
    }

    public static Vector3 Ease(Vector3 current, Vector3 target, float percentAfter1Sec, float dt)
    {
        float p = 1 - Mathf.Pow(percentAfter1Sec, dt);

        return Lerp(current, target, p);
    }


}
