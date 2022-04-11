using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tutorialPlus : MonoBehaviour
{
    private GameSystem gameSystem;
    void Start()
    {
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
            gameSystem.GetComponent<TutorialSystem>().TutorialStep++;
        }
    }
}
