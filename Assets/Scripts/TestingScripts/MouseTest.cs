using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("Mouse just enter the: " + this.gameObject.name);
        transform.eulerAngles = new Vector3(-0,180,0);
    }
    
    private void OnMouseExit()
    {
        Debug.Log("Mouse just exited the: " + this.gameObject.name);
        transform.eulerAngles = new Vector3(-15,180,0);
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("The player just presed the button");

        switch (gameObject.name)
        {
            case "DificultyButton":
                //TODO: Change the dificulty MAKE THE MENU FOR THAT
                break;
            
            case "LevelButton":
                //TODO: make level switching
                break;
            
            case "PlayButton":
                //TODO: load the current level that is selected
                break;
            
            
            default:
                break;
        }
    }
}
