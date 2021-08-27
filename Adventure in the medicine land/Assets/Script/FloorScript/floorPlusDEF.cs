using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorPlusDEF : Floor
{
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
        inRange = true;
        setTypeFloor();
    }

    protected override void setTypeFloor()
    {
        floorColor = new Color(0.5019608f, 0.5019608f, 0.5019608f, 1f);
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine")
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialDefense += 1;
        }
    }
}
