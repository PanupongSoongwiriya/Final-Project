using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    private Character chr;
    public GameObject system;
    protected GameSystem gameSystem;
    private bool testddd;
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
        chr = gameObject.GetComponent<Character>();
        testddd = true;
    }

    void Update()
    {
        if (gameSystem.whoTurn == "Disease" && testddd)
        {
            testddd = false;
            Invoke("testDelay", 1.0f);
        }
    }

    private void testDelay()
    {
        testddd = true;
        gameSystem.NowCharecter = chr;
        gameSystem.allFloor[new System.Random().Next(gameSystem.allFloor.Count)].GetComponent<Floor>().setPositionCharacter();
    }
}
