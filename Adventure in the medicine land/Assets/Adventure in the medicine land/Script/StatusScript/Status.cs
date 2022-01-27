using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Status : MonoBehaviour
{
    public String statusName;
    public String desCripTion;
    public String statusType;
    public String Type;
    protected int numEffect;
    protected int numEffect_2;
    protected int odDmg;
    public Color color;
    public GameSystem gameSystem;

    public virtual void changeState()
    {
    }
    public virtual void cancelStatus()
    {
    }

    public virtual void retrospectiveStatus(Character c)
    {
    }
    
    public virtual void statusEffect(Character c)
    {
    }
    public virtual bool IsStatusEffective(Status s)
    {
        return false;
    }

    public void overDosage(Character c)
    {
        if (c.characterStatus.Equals(this))
        {
            c.hp += odDmg;
            c.showDMG(odDmg, "attack");
        }
    }

    protected void startSet(String sn, String dct, String st, String t, int ne, int ne2, Color c)
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
        Type = t;
        numEffect = ne;
        numEffect_2 = ne2;
        color = c;
        odDmg = -1;
    }

}
