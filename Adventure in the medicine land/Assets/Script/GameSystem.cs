using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    private int turn;
    private string state;//("Choose a player character", "waiting for orders", "walk", "Choose a enemy character", "round of bots")
    private Character charecterPlayer;
    private GameObject charecterEnimy;
    void Start()
    {
        turn = 0;
        state = "Choose a player character";
    }

    void Update()
    {

    }
    public string State
    {
        get { return state; }
        set { state = value; }
    }
    public Character Player
    {
        get { return charecterPlayer; }
        set { charecterPlayer = value; }
    }
    public GameObject Enimy
    {
        get { return charecterEnimy; }
        set { charecterEnimy = value; }
    }

}
