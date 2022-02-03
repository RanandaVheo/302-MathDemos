using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QCubicDemo : MonoBehaviour
{
    public Transform AnchorStart;
    public Transform AnchorEnd;
    public Transform ControlStart;
    public Transform ControlEnd;

    [Range(2, 100)]
    public int CurveRes = 10;

    public float TweenTimeLength = 3;
    public float TweenTimeCurrent = 0;

    private bool IsPlaying = false;

    public AnimationCurve temporalEasing;

    void Update()
    {
        if (IsPlaying) TweenTimeCurrent += Time.deltaTime;

        float p = Mathf.Clamp(TweenTimeCurrent / TweenTimeLength, 0, 1);

        p = temporalEasing.Evaluate(p);
        Vector3 pos = FindPointOnCurve(p);
        transform.position = pos;

        Vector3 pos2 = FindPointOnCurve(p + .05f);

        Vector3 curveForward = (pos2 - pos).normalized;

        Quaternion rot = Quaternion.LookRotation(curveForward);
        transform.rotation = rot;

        if (TweenTimeCurrent >= TweenTimeLength) IsPlaying = false;
    }

    public void PlayTween(bool fromBeginning = true)
    {
        IsPlaying = true;
        if (fromBeginning) TweenTimeCurrent = 0;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < CurveRes; i++)
        {
            Vector3 a = FindPointOnCurve(i / (float)CurveRes);
            Vector3 b = FindPointOnCurve((i + 1)/ (float)CurveRes);

            Gizmos.DrawLine(a, b);
        }
    }

    Vector3 FindPointOnCurve(float percent)
    {
        //A = pt between: start control, end control
        Vector3 a = AniMath.Lerp(ControlStart.position, ControlEnd.position, percent);

        //B = pt between: start anchor, start control
        //C = pt between: end control, end anchor
        Vector3 b = AniMath.Lerp(AnchorStart.position, ControlStart.position, percent);
        Vector3 c = AniMath.Lerp(ControlEnd.position, AnchorEnd.position, percent);

        //D = pt between: B, A
        //E = pt between: A, C
        Vector3 d = AniMath.Lerp(b, a, percent);
        Vector3 e = AniMath.Lerp(a, c, percent);

        //F = pt between: D, E
        return AniMath.Lerp(d, e, percent);
    }
}

[CustomEditor(typeof(QCubicDemo))]
public class QCubicEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Play Tween"))
        {
            (target as QCubicDemo).PlayTween();
        }
    }


}
