using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defendButton : MonoBehaviour
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
            gameSystem.Player.specialDefense = 1;
            gameSystem.State = "Choose a player character";
            Debug.Log(gameSystem.State);
            Debug.Log(gameSystem.Player.specialDefense);
            controlPanel.gameObject.SetActive(false);
        }
    }
}
