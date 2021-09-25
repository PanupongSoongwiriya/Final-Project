using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    private Character chr;
    public GameSystem gameSystem;
    //public bool botActive;
    void Start()
    {
        chr = gameObject.GetComponent<Infect>();
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }

    public void botWalk()
    {
        gameSystem.cf.Target = transform;
        gameSystem.NowCharecter = chr;
        if (chr.walkingDistance > 0)
        {
            gameSystem.botChackInTerm();
            gameSystem.allFloorInTerm[new System.Random().Next(gameSystem.allFloorInTerm.Count)].GetComponent<Floor>().setPositionCharacter();
        }
        else
        {
            gameSystem.NowCharecter.doneIt();
        }
    }
}
