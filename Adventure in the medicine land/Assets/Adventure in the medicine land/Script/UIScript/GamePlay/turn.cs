using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class turn : MonoBehaviour
{
    Text txt;
    protected GameSystem gameSystem;
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
        txt = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        txt.text = ThaiFontAdjuster.Adjust("เทิร์น: " + gameSystem.Turn);
    }
}
