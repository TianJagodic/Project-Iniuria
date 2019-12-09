using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
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

    public float leftStopper;
    public float rightStopper;

    public static int Mode = 0; //can be 0, 1, 2
    public int DificultySetting = 0; //can be 0, 1, 2
    
    private float timer = 0.0f;
    private Rigidbody RB;
    
    private float nextActionTime = 0.0f;
    public float period = 4f;
    
    public Material sphereMaterial;
    
    //VFX Gradients section
    public Gradient vfxGradient;
    public VisualEffect VFX;
    public bool bloome;
    private float VFXtime = 0.0f;
    
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        VFX.SetInt("SpawnRate", 0);
        InvokeRepeating("Move", 0f, 1f);
    }
    
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        Dificulty(timer);

        if (bloome && VFXtime + 5 >= timer)
        { 
            VFX.SetInt("SpawnRate", 0);
            bloome = false;
        }

    }

    void Move()
    {
        Vector3 jumpRight = new Vector3(jumpForceX,jumpForceY);
        Vector3 jumpLeft = new Vector3(-jumpForceX, jumpForceY);

        if (transform.position.x <= leftStopper || transform.position.x >= rightStopper)
        {
            if (transform.position.x <= leftStopper)
            {
                RB.AddForce(jumpRight);
            }
            else
            {
                RB.AddForce(jumpLeft);
            }
        }
        else
        {
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
                Shader(enemy.color, GetComponent<Renderer>().material.color);
                GetComponent<Renderer>().material = enemy;
                Mode = 0;
                break;
            
            case 1:
                Shader(cry.color, GetComponent<Renderer>().material.color);
                GetComponent<Renderer>().material = cry;
                Mode = 1;
                break;
            
            case 2:
                Shader(good.color, GetComponent<Renderer>().material.color);
                GetComponent<Renderer>().material = good;
                Mode = 2;
                break;
        }
        
        
    }

    void Shader(Color newColor, Color oldColor)
    {
        Debug.Log("New mode");
        sphereMaterial.SetColor("_Color", newColor);
        
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;
        
        colorKey = new GradientColorKey[2];
        colorKey[0].color = oldColor;
        colorKey[0].time = 0.0f;
        colorKey[1].color = newColor;
        colorKey[1].time = 1.0f;
        
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1;
        alphaKey[1].time = 1.0f;

        
        vfxGradient.SetKeys(colorKey, alphaKey);
        
        VFX.SetGradient("CurrentGradient", vfxGradient);
        VFX.SetInt("SpawnRate", 25000);

        bloome = !false;
        VFXtime = timer;
    }
    
}
