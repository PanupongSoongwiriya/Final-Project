using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorMinusDEF : Floor
{
    public int SD = -1;
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        setTypeFloor();
    }

    protected override void setTypeFloor()
    {
        floorColor = new Color(0.6470588f, 0.1647059f, 0.1647059f, 1f);
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            characterOnIt = collision.gameObject.GetComponent<Character>();
            characterOnIt.PedalFloor = this;
            characterOnIt.specialDefense += SD;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        characterOnIt.specialDefense -= SD;
        characterOnIt = null;
    }
    public override void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.specialDefense = SD;
        }
    }
}
