using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public static float PlayerPoints = 30;
    public static float itPoints = 30;

    public static float pointsMulipler = 0.5f;

    public static void ReciveData()
    {
        switch (it.Mode)
        {
            case 0://enemy
                PlayerPoints -= pointsMulipler * (itPoints / 100);
                itPoints -= pointsMulipler * (PlayerPoints / 100);
                
                
                break;
            
            
            case 1://cry
                PlayerPoints -= pointsMulipler * Math.Abs((itPoints - 100) / 100);
                itPoints += pointsMulipler * (PlayerPoints / 100);
                
                //Debug.Log("We landed in here case 1");
                break;
            
            
            case 2://good
                PlayerPoints += pointsMulipler * (itPoints / 100);
                itPoints += pointsMulipler * (PlayerPoints / 100);
                
                //Debug.Log("We landed in here case 2");
                break;
        }
        
        
    }

    void FixedUpdate()
    {
        if (it.Mode == 1 && itDetection.isDetected)
        {
            PlayerPoints += pointsMulipler * Math.Abs((itPoints - 100) / 100);
            itPoints -= pointsMulipler * Math.Abs((PlayerPoints - 100) / 100);
        }
    }

    private void Update()
    {
        Debug.Log("P: " + PlayerPoints + "   ;   it: " + itPoints);
    }
}
