using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbitPlayer : MonoBehaviour
{
    public float speed;

    //토끼 움직임
    float hAxis;
    float vAxis;

    Vector3 moveVec;

   

    void Start()
    {
        
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        //움직임, 속도 일정하게
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        
    }

}
