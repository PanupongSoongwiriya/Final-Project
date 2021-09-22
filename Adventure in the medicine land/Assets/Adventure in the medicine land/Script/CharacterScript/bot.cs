using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    private Character chr;
    public GameSystem gameSystem;
    public bool botActive;
    void Start()
    {
        chr = gameObject.GetComponent<Infect>();
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        botActive = false;

    }

    void Update()
    {
        if (botActive)
        {
            botWalk();
        }
    }

    private void botWalk()
    {
        botActive = false;
        gameSystem.cf.Target = transform;
        gameSystem.NowCharecter = chr;
        gameSystem.botChackInTerm();
        gameSystem.allFloorInTerm[new System.Random().Next(gameSystem.allFloorInTerm.Count)].GetComponent<Floor>().setPositionCharacter();
    }
}
