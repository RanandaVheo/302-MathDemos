using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseDemo : MonoBehaviour
{

    public Transform target;
    public float percentAfter1Sec = 0.0001f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // wrong way     transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);

        transform.position = AniMath.Ease(transform.position, target.position, percentAfter1Sec, Time.deltaTime);
    }
}
