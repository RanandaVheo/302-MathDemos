using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    //[Range(0, 1)] 
    public float percent = 0;

    void DoInterpolation()
    {
        if (pointA == null) return;
        if (pointB == null) return;

        // set this object's position to the lerp result
        Vector3 pos = AniMath.Lerp(pointA.position, pointB.position, percent, false);

        // set this object's rotation to the lerp result
        Quaternion rot = AniMath.Lerp(pointA.rotation, pointB.rotation, percent);

        transform.position = pos;
        transform.rotation = rot;
    }

    private void OnValidate()
    {
        DoInterpolation();
    }
}
