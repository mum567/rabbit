using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //토끼가 돌을 던진다

    public GameObject bullet;
    public float bulletspeed = 10.0f;

    private Rigidbody rigidbody;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            GameObject newBullet = Instantiate(bullet,transform.position + transform.forward, transform.rotation) as GameObject;
            Rigidbody rbBullet = newBullet.GetComponent<Rigidbody>();
            rbBullet.velocity = transform.forward * bulletspeed;
        }
    }
}
