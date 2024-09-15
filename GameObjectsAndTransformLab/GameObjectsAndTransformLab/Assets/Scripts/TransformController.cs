using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    void Update()
    {
        var x = Mathf.PingPong(Time.time, 3);
        var p = new Vector3(x, 0, 0);
        transform.position = p;

        transform.Rotate(new Vector3(0, 0, 70) * Time.deltaTime);
    }
}
