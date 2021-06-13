using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneControl : MonoBehaviour
{
    //돌 던지는거 조정
    public float bulletTime = 3.0f;

    void Start()
    {
        Destroy(gameObject, bulletTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
