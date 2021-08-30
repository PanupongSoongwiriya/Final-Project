using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorPoison : Floor
{
    public int poison = 1;
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
        setTypeFloor();
    }

    protected override void setTypeFloor()
    {
        floorColor = new Color(0.5019608f, 0f, 0.5019608f, 1f);
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            changeTurn = false;
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.hp -= poison;
            charecterPlayer.checkHP();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease") && changeTurn)
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.hp -= poison;
            changeTurn = false;
        }
    }
}
