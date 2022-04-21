using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tutorialPlus : MonoBehaviour
{
    private GameSystem gameSystem;
    private bool plus;
    void Start()
    {
        plus = true;
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }
    }
    private void OnMouseDown()
    {
        if (gameSystem.name.Equals("TutorialSystem"))
        {
            if (gameSystem.GetComponent<TutorialSystem>().TutorialStep != 13)
            {
                if(plus){
                    plus = false;
                    gameSystem.GetComponent<TutorialSystem>().TutorialStep++;
                    Invoke("resetPlus", 0.15f);
                }
            }
        }
    }
    private void resetPlus(){
        plus = true;
    }
}
