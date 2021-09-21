using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainTonic : Character
{
    void Start()
    {
        characterName = "Ginkgo";
        faction = "Medicine";
        classCharacter = "บำรุงสมอง";
        genusPhase = "ระยะไกล";

        HP = 10;
        attackPower = 2;
        defensePower = 1;

        walkingDistance = 2;
        attackRange = 3;

        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        gameSystem.memberUpdate(this);
        doneItYet = true;

        allSkill.Add(new BootATK(gameSystem, this));
    }

    void Update()
    {
        //resetSP();
    }
    void OnMouseDown()
    {
        showDetailDisease();
        prepare();
        attacked();
        checkBuffDebuff();
    }
}
