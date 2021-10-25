using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class whoTurn : MonoBehaviour
{
    Text txt;
    protected GameSystem gameSystem;
    Image img;
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
        img = GetComponent<Image>();
        txt.text = ThaiFontAdjuster.Adjust("เทิร์นของผู้เล่น");
        img.color = new Color(0, 255, 0, 1);
    }

    public void Changed()
    {
        if (gameSystem.whoTurn.Equals("Medicine"))
        {
            txt.text = ThaiFontAdjuster.Adjust("เทิร์นของผู้เล่น");
            img.color = new Color(0, 255, 0, 1);
        }
        else
        {
            txt.text = ThaiFontAdjuster.Adjust("เทิร์นของฝ่ายตรงข้าม");
            img.color = new Color(255, 0, 0, 1);
        }
    }
}
