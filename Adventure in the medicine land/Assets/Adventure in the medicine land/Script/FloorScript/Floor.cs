using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    protected GameObject Character;
    public GameObject system;
    protected GameSystem gameSystem;
    protected bool inTerm = false;
    protected Color floorColor;
    public bool changeTurn = false;
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
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
            setPositionCharacter();
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
    }
    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease") && changeTurn)
        {
            Character charecterPlayer = collision.gameObject.GetComponent<Character>();
            charecterPlayer.specialDefense = 0;
            charecterPlayer.specialAttack = 0;
            changeTurn = false;
        }
    }

    public void setPositionCharacter()
    {
        gameSystem.NowCharecter.doneIt();
        gameSystem.NowCharecter.transform.position = new Vector3(transform.position.x, gameSystem.NowCharecter.transform.position.y, transform.position.z);//getposition for move Character
        gameSystem.checkChangeTurn();
        gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
    }

    public bool InTerm
    {
        get { return inTerm; }
        set { inTerm = value; }
    }
}
