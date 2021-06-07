using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private float secondPerRealTimeSecound; // 게임 세계의 100초 = 현실 세계의 1초

    private bool isNight = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right,0.1f * secondPerRealTimeSecound * Time.deltaTime);

    }
}
