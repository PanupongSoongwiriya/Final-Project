using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    protected GameObject Character;
    public GameObject system;
    protected GameSystem gameSystem;
    protected bool inRange = true;
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
        if (gameSystem.State.Equals("walk") && inRange)
        {
            setPositionCharacter();
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Debug.Log("--------------------------------------");
        Debug.Log("Who: " + collision.gameObject.name);
        Debug.Log("Floor: " + floorColor);
    }

    public void setPositionCharacter()
    {
        gameSystem.NowCharecter.doneIt();
        gameSystem.NowCharecter.transform.position = new Vector3(transform.position.x, gameSystem.NowCharecter.transform.position.y, transform.position.z);//getposition for move Character
        gameSystem.State = "Choose a medicine character";
        gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false);
    }
}
