using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorMinusDEF : Floor
{
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
        setTypeFloor();
        inRange = true;
    }

    protected override void setTypeFloor()
    {
        floorColor = new Color(0.6470588f, 0.1647059f, 0.1647059f, 1f);
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine")
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialDefense -= 1;
        }
    }
}
