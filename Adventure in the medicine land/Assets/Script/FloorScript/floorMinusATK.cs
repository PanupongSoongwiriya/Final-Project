using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorMinusATK : Floor
{
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
        inRange = true;
        setTypeFloor();
    }

    protected override void setTypeFloor()
    {
        floorColor = Color.cyan;
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine")
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialAttack -= 1;
        }
    }
}
