using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itDetection : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PointsSystem.ReciveData();
        }
    }
}
