using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    private Character chr;
    public GameSystem gameSystem;
    void Start()
    {
        chr = gameObject.GetComponent<Infect>();
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }

    public void botActive()
    {
        gameSystem.cf.Target = transform;
        gameSystem.NowCharecter = chr;
        gameSystem.botChackInTerm("attack");
        if (gameSystem.allMedicineInTerm.Count != 0)
        {
            botAttack();
        }
        else {
            botWalk();
        }
    }

    private void botWalk()
    {
        gameSystem.botChackInTerm("walk");
        if (gameSystem.NowCharecter.walkingDistance > 0)
        {
            gameSystem.allFloorInTerm[new System.Random().Next(gameSystem.allFloorInTerm.Count)].GetComponent<Floor>().setPositionCharacter();
        }
        else
        {
            gameSystem.NowCharecter.doneIt();
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
            gameSystem.NowCharecter.doneIt();
        }
    }
}
