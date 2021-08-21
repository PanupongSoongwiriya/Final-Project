using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private GameObject Character;
    public GameObject system;
    private GameSystem gameSystem;
    private bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        inRange = true;
        gameSystem = system.GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setTypeFloor(string type, Color pixFloor)//test
    {
        //Debug.Log(type);
        this.GetComponent<Renderer>().material.SetColor("_Color", pixFloor);
    }
    void OnMouseDown()
    {
        // this object was clicked - do something
        //Destroy(this.gameObject);
        if (gameSystem.State.Equals("walk") && inRange)
        {
            gameSystem.Player.transform.position = this.transform.position;
            gameSystem.State = "Choose a player character";
            Debug.Log(gameSystem.State);
            //Debug.Log(this.GetComponent<Transform>().position); //getposition for move Character
        }
    }
    public GameObject test
    {
        get { return system; }
        set { system = value; }
    }
}
