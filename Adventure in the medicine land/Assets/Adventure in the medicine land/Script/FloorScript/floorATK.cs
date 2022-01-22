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
            if (characterOnIt != null)
            {
                if (characterOnIt.Equals(collision.gameObject.GetComponent<Character>()))
                {
                    characterOnIt.SP_Atk += floorBonus;
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
                characterOnIt.SP_Atk -= floorBonus;
                characterOnIt = null;
            }
        }
            
    }
    public override void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.SP_Atk = floorBonus;
            /*if (characterOnIt.faction.Equals("Medicine") & characterOnIt.characterStatus != null)
            {
                characterOnIt.characterStatus.statusEffect(characterOnIt);
            }*/
        }
    }

}
