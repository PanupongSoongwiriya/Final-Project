using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Status : MonoBehaviour
{
    public String statusName;
    public String desCripTion;
    protected int numEffect;
    protected int numEffect_2;
    public Color color;
    protected String effectType;
    protected String statusType;
    public GameSystem gameSystem;
    public Character chr;

    public virtual void changeState()
    {
    }
    public virtual void cancelStatus()
    {
    }
    public virtual void statusEffect()
    {
    }

    protected void startSet(String sn, String dct, String st, String et, int ne, int ne2, Color c)
    {
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }

        statusName = sn;
        desCripTion = dct;
        statusType = st;
        effectType = et;
        numEffect = ne;
        numEffect_2 = ne2;
        color = c;
    }

    public Character Chr
    {
        get { return chr; }
        set { chr = value; }
    }
}
