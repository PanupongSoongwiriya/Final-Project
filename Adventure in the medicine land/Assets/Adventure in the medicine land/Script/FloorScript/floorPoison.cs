using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class floorPoison : Floor
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
        typrFloor = "poison";
    }

    protected override void setTypeFloor()
    {
        floorColor = new Color(0.5019608f, 0f, 0.5019608f, 1f);
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
                    floorEffect();
                }
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        characterOnIt = null;
    }
    public override void floorEffect()
{
        if (characterOnIt != null)
        {
            characterOnIt.HP -= floorBonus;
            characterOnIt.showDMG(-floorBonus, typrFloor);
        }
    }
}
