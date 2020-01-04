using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itDetection : MonoBehaviour
{

    public static bool isDetected = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isDetected = false;
        }
    }
    
    private void FixedUpdate()
    {
        PointsSystem.ReciveData();
    }
}
