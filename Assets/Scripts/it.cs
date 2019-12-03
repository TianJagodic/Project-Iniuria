using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class it : MonoBehaviour
{
    
    /*
     * Both dificulty and mode can be three dirfent settings
     * d1 = easy
     * d2 = hard
     * d3 = witch
     *
     * m1 = enemy or angry
     * m2 = crying
     * m3 = good or friendly
     */
    
    public Material good;
    public Material enemy;
    public Material cry;

    public float jumpForceX;
    public float jumpForceY;

    public static int Mode = 0; //can be 0, 1, 2
    public int DificultySetting = 0; //can be 0, 1, 2
    
    private float timer = 0.0f;
    private Rigidbody RB;
    
    private float nextActionTime = 0.0f;
    public float period = 4f;
 

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        InvokeRepeating("Move", 0f, 2f);
    }
    
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        Dificulty(timer);
        
    }

    void Move()
    {
        Vector3 jumpRight = new Vector3(jumpForceX,jumpForceY);
        Vector3 jumpLeft = new Vector3(-jumpForceX, jumpForceY);
        

        switch (Random.Range(0,2))
        {
            case 0:
                RB.AddForce(jumpRight);
                break;
            case 1:
                RB.AddForce(jumpLeft);
                break;
        }
    }

    void Dificulty(float time)
    {
        //Debug.Log(timer);
        switch (DificultySetting)
        {
           case 0:
               if (time >= 6)
               {
                   //easy
                   timer -= 6.0f;
                   ChangeMode();
                   Move();
               }
               break;
           case 1:
               if(time >= 5)
               {
                   //hard
                   timer -= 5.0f;
                   ChangeMode();
                   Move();
               }
               break;
           case 2:
               if (time >= 3)
               {
                   //witch
                   timer -= 3.0f;
                   ChangeMode();
                   Move();
               }
               break;
        }
    }

    void ChangeMode()
    {
        int mode = Random.Range(0, 3);

        switch (mode)
        {
            case 0:
                GetComponent<Renderer>().material = enemy;
                Mode = 0;
                break;
            
            case 1:
                GetComponent<Renderer>().material = cry;
                Mode = 1;
                break;
            
            case 2:
                GetComponent<Renderer>().material = good;
                Mode = 2;
                break;
        }
    }
}
