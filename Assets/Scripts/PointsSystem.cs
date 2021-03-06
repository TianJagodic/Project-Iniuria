﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsSystem : MonoBehaviour
{
    public static float PlayerPoints = 30;
    public static float itPoints = 30;

    public static float pointsMulipler = 0.07f;

    public static bool isComplete = false;

    public TextMesh itTEXT;
    public TextMesh playerTEXT;


    //Both of the end of game sings
    public GameObject Won;
    public GameObject Lost;
    
    //All the model numbers are here
    public Transform NumberOne;
    public Transform NumberTwo;
    public Transform NumberThree;
    public Transform NumberFour;
    public Transform NumberFive;
    public Transform NumberSix;
    public Transform NumberSeven;
    public Transform NumberEgiht;
    public Transform NumberNine;
    
    void Start(){
        Time.timeScale = 1;
        PlayerPoints = 30;
        itPoints = 30;

        pointsMulipler = 0.07f;
        isComplete = false;
        
    }

    public static void ReciveData()
    {
        switch (it.Mode)
        {
            case 0://enemy
                if (itDetection.isDetected)
                {
                    PlayerPoints -= pointsMulipler;// * (itPoints / 100);
                    itPoints -= pointsMulipler;// * (PlayerPoints / 100);
                }
                break;
            
            
            case 1://cry
                
                if (itDetection.isDetected)
                {
                    PlayerPoints -= pointsMulipler; //* 1 * (itPoints / 100);
                    itPoints += pointsMulipler;// * 1 * (PlayerPoints / 100);
                }
                else if(itDetection.isDetected == false)
                {
                    PlayerPoints += pointsMulipler;// * (itPoints / 100);
                    itPoints -= pointsMulipler;// * (PlayerPoints / 100);
                }
                break;
            
            
            case 2://good
                if (itDetection.isDetected)
                {
                    PlayerPoints += pointsMulipler;// * (itPoints / 100);
                    itPoints += pointsMulipler; // * (PlayerPoints / 100);
                }
                break; 
               
        }
        
    }

    void FixedUpdate()
    {
        if(itPoints >= 100 && PlayerPoints >= 100){
            EndOfGame("Won");
        }

        if(itPoints <= 0 || PlayerPoints <= 0){
            EndOfGame("Lost");
        }

        
    }


    void EndOfGame(string Condition){
        if(Condition == "Won"){
            //WON THE GAME
            Won.SetActive(true); 
            Time.timeScale = 0.000001f;
            isComplete = true;
        }
        else{
            isComplete = true;
            Time.timeScale = 0.000001f;
            Lost.SetActive(true); 
            //LOST THE GAME
        }
    }

    private void Update()
    {
        itTEXT.text = Math.Round(itPoints, 1).ToString();
        playerTEXT.text = Math.Round(PlayerPoints, 1).ToString();

        if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Return)) && isComplete){
            Debug.Log("We are trying to load the MainMenu");
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }

    private void CreateNumber(decimal number)
    {
        string NumberString = Math.Round(number, 1).ToString();

        foreach (char VARIABLE in NumberString)
        {
            switch (VARIABLE)
            {
                case (char) 48:
                    break;
                case (char) 49:
                    break;
                case (char) 50:
                    break;
                case (char) 51:
                    break;
                case (char) 52:
                    break;
                case (char) 53:
                    break;
                case (char) 54:
                    break;
                case (char) 55:
                    break;
                case (char) 56:
                    break;
                case (char) 57:
                    break;
            }
        }

    }
}
