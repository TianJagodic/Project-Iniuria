﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float torque;
    public float jumpforce;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float turn = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(Vector3.back * torque * turn);

        if (Input.GetButtonUp("Jump") && transform.position.y <= -0.99f)
        {
            Vector3 jump = new Vector3(0.0f, jumpforce, 0.0f);
            rb.AddForce(jump);
        }
    }
}
