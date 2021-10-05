using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorATK : Floor
{
    public int sa;
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }

    protected override void setTypeFloor()
    {
        if (sa < 0)
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
            if (characterOnIt.Equals(collision.gameObject.GetComponent<Character>()))
            {
                characterOnIt.specialAttack += sa;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (characterOnIt.Equals(collision.gameObject.GetComponent<Character>()))
        {
            characterOnIt.specialAttack -= sa;
            characterOnIt = null;
        }
    }
    public override void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.specialAttack = sa;
        }
    }

    public int SA
    {
        get { return sa; }
        set { sa = value; setTypeFloor(); }
    }
}
