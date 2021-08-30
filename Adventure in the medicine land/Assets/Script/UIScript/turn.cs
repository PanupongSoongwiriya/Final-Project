using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turn : MonoBehaviour
{
    Text txt;
    public GameObject system;
    protected GameSystem gameSystem;
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        txt.text = "Turn : " + gameSystem.turn;
    }
}
