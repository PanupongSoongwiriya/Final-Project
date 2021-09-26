using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorDEF : Floor
{
    public int sd;
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }

    protected override void setTypeFloor()
    {
        if (sd < 0)
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
            characterOnIt = collision.gameObject.GetComponent<Character>();
            characterOnIt.PedalFloor = this;
            characterOnIt.specialDefense += sd;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        characterOnIt.specialDefense -= sd;
        characterOnIt = null;
    }
    public override void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.specialDefense = sd;
        }
    }
    public int SD
    {
        get { return sd; }
        set { sd = value; setTypeFloor(); }
    }
}