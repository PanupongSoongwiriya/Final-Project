using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class floorDEF : Floor
{
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
        typrFloor = "DEF";
    }

    protected override void setTypeFloor()
    {
        if (floorBonus < 0)
        {
            floorColor = new Color(0.6470588f, 0.1647059f, 0.1647059f, 1f);
        }
        else
        {
            floorColor = new Color(0.5019608f, 0.5019608f, 0.5019608f, 1f);
        }
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            if (collision.gameObject.GetComponent<Character>().PedalFloor == null)
            {
                characterOnIt = collision.gameObject.GetComponent<Character>();
                characterOnIt.PedalFloor = this;
            }
            if (characterOnIt != null)
            {
                if (characterOnIt.Equals(collision.gameObject.GetComponent<Character>()))
                {
                    characterOnIt.specialDefense += floorBonus;
                    characterOnIt.showDMG(floorBonus, typrFloor);
                }
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (characterOnIt != null)
        {
            if (characterOnIt.Equals(collision.gameObject.GetComponent<Character>()))
            {
                characterOnIt.specialDefense -= floorBonus;
                characterOnIt = null;
            }
        }
    }
    public override void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.specialDefense = floorBonus;
        }
    }
}
