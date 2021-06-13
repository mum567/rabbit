using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 camOff = new Vector3(0.0f, 1.5f, -2.6f);
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.TransformPoint(camOff);
        transform.LookAt(target);
    }
}
