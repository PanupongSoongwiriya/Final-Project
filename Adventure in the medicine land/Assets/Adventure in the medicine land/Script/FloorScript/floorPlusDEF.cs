using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorPlusDEF : Floor
{
    public int SD = 1;
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        setTypeFloor();
    }

    protected override void setTypeFloor()
    {
        floorColor = new Color(0.5019608f, 0.5019608f, 0.5019608f, 1f);
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialDefense += SD;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease") && changeTurn)
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialDefense = SD;
            changeTurn = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialDefense -= SD;
        }
    }
}
