using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Floor : MonoBehaviour
{
    public Character characterOnIt;
    protected GameSystem gameSystem;
    public bool inTerm = false;
    public int floorBonus = 0;
    protected Color floorColor;
    public String typrFloor;

    public Character test;
    void Start()
    {
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }
        FloorBonus = 0;
        typrFloor = "Normal";
    }
    protected void Update()
    {
        if (test != characterOnIt)
        {
            /*Debug.Log(name + " old: " + test);
            Debug.Log(name + " new: " + characterOnIt);*/
            test = characterOnIt;
        }
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
            tutorialPlus();
            gameSystem.NowCharecter.PedalFloor = this;
        }
    }

    public void showInTerm(String doingWhat)
    {
        GameObject show = transform.GetChild(0).gameObject;
        show.SetActive(inTerm);
        Animator anim = show.GetComponent<Animator>();
        GameObject frame = show.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        //Debug.Log("name: " + frame.name);
        if (doingWhat.Equals("walk"))
        {
            anim.SetInteger("Color", 0);
            frame.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 1, 1, 1));
        }
        else if(doingWhat.Equals("support"))
        {
            anim.SetInteger("Color", 1);
            frame.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 1, 0, 1));
        }
        else if (doingWhat.Equals("bad for the enemy"))
        {
            anim.SetInteger("Color", 2);
            frame.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0, 1));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*Debug.Log("typeof: " + collision.gameObject.GetComponent(typeof(Character)));
        if (collision.gameObject.GetComponent(typeof(Character)))
        {
            Debug.Log("Hello World");
        }*/
        if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            //Debug.Log("typeof: " + collision.gameObject.GetComponent(typeof(Character)));
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
    protected void tutorialPlus()
    {
        if (gameSystem.name.Equals("TutorialSystem"))
        {
            gameSystem.GetComponent<TutorialSystem>().TutorialStep++;
        }
    }

    public virtual void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.specialDefense = 0;
            characterOnIt.specialAttack = 0;
        }
    }
    public int FloorBonus
    {
        get { return floorBonus; }
        set { floorBonus = value; //setTypeFloor(); 
        }
    }


    public bool InTerm
    {
        get { return inTerm; }
        set { inTerm = value; }
    }
}
