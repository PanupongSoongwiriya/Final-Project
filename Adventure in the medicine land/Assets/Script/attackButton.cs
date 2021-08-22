using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackButton : MonoBehaviour
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
            gameSystem.State = "Choose a enemy character";
            Debug.Log(gameSystem.State);
            //controlPanel.gameObject.SetActive(false);
        }
    }
}
