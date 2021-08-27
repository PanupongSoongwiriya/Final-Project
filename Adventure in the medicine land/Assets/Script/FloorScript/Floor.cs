using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    protected GameObject Character;
    public GameObject system;
    protected GameSystem gameSystem;
    protected bool inRange;
    protected Color floorColor;
    // Start is called before the first frame update
    void Start()
    {
        inRange = true;
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
            gameSystem.Player.transform.position = new Vector3(transform.position.x, gameSystem.Player.transform.position.y, transform.position.z);//getposition for move Character
            gameSystem.State = "Choose a player character";
            Debug.Log(gameSystem.State);
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Debug.Log("--------------------------------------");
        Debug.Log("Who: " + collision.gameObject.name);
        Debug.Log("Floor: " + floorColor);
    }
}
