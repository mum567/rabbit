using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //토끼 이동 속도
    float rbMvSpeed = 10.0f;

    //토끼 회전 속도
    float rbRotSpeed = 150.0f;

    void Start()
    {
        
    }

      void Update()
    {
        float mv = Input.GetAxis("Vertical1") * rbMvSpeed * Time.deltaTime;
        float rot = Input.GetAxis("Horizontal1") * rbRotSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, rot, 0);

    }

   
}
