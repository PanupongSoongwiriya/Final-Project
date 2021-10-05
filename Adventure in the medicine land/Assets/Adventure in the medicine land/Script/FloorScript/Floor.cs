using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Floor : MonoBehaviour
{
    public Character characterOnIt;
    protected GameSystem gameSystem;
    public bool inTerm = false;
    protected Color floorColor;
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        setTypeFloor();
    }

    protected virtual void setTypeFloor()
    {
        floorColor = Color.white;
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    void OnMouseDown()
    {
        if (gameSystem.State.Equals("walk") && inTerm)
        {
            gameSystem.NowCharecter.PedalFloor = this;
        }
    }

    public void showInTerm(String doingWhat)
    {
        GameObject show = transform.GetChild(0).gameObject;
        show.SetActive(inTerm);
        if (doingWhat.Equals("walk"))
        {
            show.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 1, 0.25f));
        }
        else if(doingWhat.Equals("support"))
        {
            show.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 1, 0, 0.25f));
        }
        else if (doingWhat.Equals("bad for the enemy"))
        {
            show.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0, 0.5f));
        }
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
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        characterOnIt = null;
    }

    public virtual void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.specialDefense = 0;
            characterOnIt.specialAttack = 0;
        }
    }


    public bool InTerm
    {
        get { return inTerm; }
        set { inTerm = value; }
    }
}
