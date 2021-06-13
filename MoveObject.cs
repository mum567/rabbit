using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//new토끼 움직이게
public class MoveObject : MonoBehaviour
{
   // public float speed = 80.0f;
    public float rotspeed = 120.0f;
    //public float jumpVelocity = 5.0f;
    

    public GameObject bullet; //돌맹이
    public float bulletspeed = 50.0f;

    private Rigidbody rigidbody;
    private GameBehavior gameManager;

    private float hInput;
    private float vInput;
    //private bool jump;
    private CapsuleCollider playerCollider;
    private AudioSource audioBullet;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();

       // jump = false;
        audioBullet = GetComponent<AudioSource>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        hInput = h * rotspeed;
       // vInput = v * speed;

       // if(Input.GetKeyDown(KeyCode.Space))
        //{
          //  jump = true;
           //}

       if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation) as GameObject;
            Rigidbody rbBullet = newBullet.GetComponent<Rigidbody>();
            rbBullet.velocity = transform.forward * bulletspeed;

            audioBullet.Play();
        }

        void FixedUpdate()
        {
            hInput = hInput * Time.fixedDeltaTime;
            vInput = vInput * Time.fixedDeltaTime;

            Vector3 rotation = Vector3.up * hInput;
            Quaternion angleRot = Quaternion.Euler(rotation);

            rigidbody.MovePosition(transform.position + transform.forward * vInput);
            rigidbody.MoveRotation(rigidbody.rotation * angleRot);
        }

        //if(jump)
        //{
          //  rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            //jump = false;
        //}

        //적이 플레이어를 따라와 충돌하게 되면 HP 감소
        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "Enemy_Tiger")
            {
                gameManager.HP -= -1;
            }
            if (collision.gameObject.name == "Enemy_BTurtle")
            {
                gameManager.HP -= -1;
            }
            if (collision.gameObject.name == "Enemy_RTurtle")
            {
                gameManager.HP -= -1;
            }
        }

    }
}
