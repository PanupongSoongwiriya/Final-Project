using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class whoTurn : MonoBehaviour
{
    Text txt;
    protected GameSystem gameSystem;
    public Sprite turnPlayer;
    public Sprite turnEnemy;
    // Start is called before the first frame update
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
        txt = GetComponentInChildren<Text>();
        GetComponent<Image>().sprite = turnPlayer;
    }

    public void Changed()
    {
        if (gameSystem.whoTurn.Equals("Medicine"))
        {
            GetComponent<Image>().sprite = turnPlayer;
        }
        else
        {
            GetComponent<Image>().sprite = turnEnemy;
        }
    }
}
