using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    public Character chr;
    public GameSystem gameSystem;

    public void botActive()
    {
        gameSystem.cf.Target = transform;
        gameSystem.NowCharecter = chr;
    }

    //When the camera arrives, Bot it works.
    public void botWork()
    {
        gameSystem.botChackInTerm(gameSystem.NowCharecter.attackRange, "bad for the enemy");
    }

    private void botWalk()
    {
        gameSystem.botChackInTerm(gameSystem.NowCharecter.walkingDistance, "walk");
        if (gameSystem.NowCharecter.walkingDistance > 0)
        {
            gameSystem.NowCharecter.PedalFloor = gameSystem.allFloorInTerm[new System.Random().Next(gameSystem.allFloorInTerm.Count)].GetComponent<Floor>();
        }
    }
    private void botAttack()
    {
        if (gameSystem.NowCharecter.attackRange > 0)
        {
            gameSystem.allMedicineInTerm[new System.Random().Next(gameSystem.allMedicineInTerm.Count)].GetComponent<Character>().attacked();
        }
        else
        {
            gameSystem.NowCharecter.doneIt(2);
            gameSystem.resetInTerm();
        }
    }
}
