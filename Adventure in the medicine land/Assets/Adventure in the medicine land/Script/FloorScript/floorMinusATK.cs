using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorMinusATK : Floor
{
    public int SA = -1;
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        setTypeFloor();
    }

    protected override void setTypeFloor()
    {
        floorColor = Color.cyan;
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            characterOnIt = collision.gameObject.GetComponent<Character>();
            characterOnIt.PedalFloor = this;
            characterOnIt.specialAttack += SA;
        }
        /*if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialAttack += SA;
        }*/
    }
    private void OnCollisionStay(Collision collision)
    {
        /*if ((collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease") && changeTurn)
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialAttack = SA;
            changeTurn = false;
        }*/
    }
    private void OnCollisionExit(Collision collision)
    {
        characterOnIt.specialAttack -= SA;
        characterOnIt = null;
        /*if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialAttack -= SA;
        }*/
    }
    public override void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.specialAttack = SA;
        }
    }
}
