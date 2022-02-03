using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuadraticDemo : MonoBehaviour
{
    public Transform ptStart;
    public Transform ptEnd;
    public Transform ptControl;

    [Range(2, 100)]
    public int curveRes = 10;

    public float TweenTimeLength = 3;
    public float TweenTimeCurrent = 0;

    private bool IsPlaying = false;

    public AnimationCurve temporalEasing;

    void Start()
    {
        
    }

    void Update()
    {
        if(IsPlaying) TweenTimeCurrent += Time.deltaTime;

        float p = TweenTimeCurrent / TweenTimeLength;
        p = Mathf.Clamp(p, 0, 1);

        p = temporalEasing.Evaluate(p);


        Vector3 pos = findPtOnCurve(p);

        transform.position = pos;

        if (TweenTimeCurrent >= TweenTimeLength) IsPlaying = false;

    }

    public void PlayTween(bool fromBeginning = false)
    {
        IsPlaying = true;
        if (fromBeginning) TweenTimeCurrent = 0;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(ptControl.position, Vector3.one);

        for (int i = 0; i < curveRes; i++)
        {
            Vector3 a = findPtOnCurve(i / (float)curveRes);
            Vector3 b = findPtOnCurve((i + 1) / (float)curveRes);

            Gizmos.DrawLine(a, b);
        }
        
    }

    Vector3 findPtOnCurve(float percent)
    {
        Vector3 a = AniMath.Lerp(ptStart.position, ptControl.position, percent);
        Vector3 b = AniMath.Lerp(ptControl.position, ptEnd.position, percent);

        return AniMath.Lerp(a, b, percent);
    }
}

[CustomEditor(typeof(QuadraticDemo))]
public class QuadraticDemoEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Play Tween"))
        {
            (target as QuadraticDemo).PlayTween(true);
        
        }
    }


}
