using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject mainModel;
    public GameObject lookHead;
    public GameObject wings;
    public GameObject body;
    public Rigidbody rb;

    // 翅膀摆动幅度
    public float wingMoveRange = 15f;
    public float flyForce = 200f;

    public float maxYVelocity = 2f;

    private void Start()
    {
        rb = lookHead.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(rb.velocity.y) > maxYVelocity)
        {
            switch (Mathf.Sign(rb.velocity.y))
            {
                case 1:
                    rb.velocity = new Vector3(rb.velocity.x, maxYVelocity, rb.velocity.z);
                    break;
                case -1:
                    rb.velocity = new Vector3(rb.velocity.x, -(maxYVelocity-1), rb.velocity.z);
                    break;
                default:
                    break;
            }
        }
    }

    public void Fly(float power)
    {
        //rb.velocity.Set(rb.velocity.x, 0, rb.velocity.z);
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        print(rb.velocity.y);
        rb.AddForce(transform.up * flyForce, ForceMode.Impulse);
        //rb.useGravity = true;
    }
}
