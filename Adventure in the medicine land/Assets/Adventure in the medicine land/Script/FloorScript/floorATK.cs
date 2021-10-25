using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class floorATK : Floor
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
        typrFloor = "ATK";
    }

    protected override void setTypeFloor()
    {
        if (floorBonus < 0)
        {
            floorColor = Color.cyan;
        }
        else
        {
            floorColor = Color.red;
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
            if (characterOnIt.Equals(collision.gameObject.GetComponent<Character>()))
            {
                characterOnIt.specialAttack += floorBonus;
                characterOnIt.showDMG(floorBonus, typrFloor);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (characterOnIt.Equals(collision.gameObject.GetComponent<Character>()))
        {
            characterOnIt.specialAttack -= floorBonus;
            characterOnIt = null;
        }
    }
    public override void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.specialAttack = floorBonus;
        }
    }

}
