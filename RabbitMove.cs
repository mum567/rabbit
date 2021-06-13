using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 75.0f;

    private float vInput;
    private float hInput;

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        transform.Rotate(Vector3.up * hInput * Time.deltaTime);

    }

}
