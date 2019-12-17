using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRolling : MonoBehaviour
{

    Rigidbody rb;
    public float torque;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -9.25f) rb.AddRelativeTorque(Vector3.back * torque * 1);
        else if (transform.position.x >= 9.25f) rb.AddRelativeTorque(Vector3.back * torque * -1);
        else if (transform.position.x >= 0) rb.AddRelativeTorque(Vector3.back * torque * -1);
        else if (transform.position.x <= 0) rb.AddRelativeTorque(Vector3.back * torque * 1);
    }
}
