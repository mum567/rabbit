using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontrol : MonoBehaviour
{
    public float bulletTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
