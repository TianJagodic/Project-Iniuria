using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itDetection : MonoBehaviour
{

    public static bool isDetected = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDetected = true;
            PointsSystem.ReciveData();
        }
        else
        {
            isDetected = !true;
        }
    }
}
