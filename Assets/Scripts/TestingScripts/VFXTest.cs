using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class VFXTest : MonoBehaviour
{
    
    //VFX Gradients section
    public Gradient vfxGradient;
    public VisualEffect VFX;
    public bool bloome;
    private float VFXtime = 0.0f;

    private float timer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        VFX.SetInt("SpawnRate", 0);
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (bloome && VFXtime + 1 >= timer)
        { 
            VFX.SetInt("SpawnRate", 0);
            bloome = false;
        }
        
        if(Input.GetKey(KeyCode.A)) Shader(Color.yellow, Color.green);
    }
    
    void Shader(Color newColor, Color oldColor)
    {
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;
        
        //sphereMaterial.SetColor("_Color", newColor);
        //vfxGradient.colorKeys[0].color = oldColor;
        //vfxGradient.colorKeys[1].color = newColor;
        
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
