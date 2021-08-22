using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelButton : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject system;
    private GameSystem gameSystem;

    public GameObject controlPanel;
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeState()
    {
        if (gameSystem.State.Equals("waiting for orders"))
        {
            gameSystem.State = "Choose a player character";
            Debug.Log(gameSystem.State);
            controlPanel.gameObject.SetActive(false);
        }
        else if (gameSystem.State.Equals("walk") || gameSystem.State.Equals("Choose a enemy character"))
        {
            gameSystem.State = "waiting for orders";
            Debug.Log(gameSystem.State);
            controlPanel.gameObject.SetActive(true);
        }
    }
}
