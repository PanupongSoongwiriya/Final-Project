using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Infect : Character
{
    void Start()
    {
        characterName = "ปีศาจไวรัส";
        faction = "Disease";
        classCharacter = "ติดเชื้อ";
        soundAttackType = "Blow";

        hp = 50;
        attackPower = 55;
        defensePower = 5;

        startSetUp();

        characterStatus = status.GetComponent<InfectStatus>();
    }
    void Update()
    {
        moveSmoothly();
        spinToTarget();
        countSetCharacterOnIt();
    }

    void OnMouseDown()
    {
        allAction();
    }

    protected override void resetRange()
    {
        walkingDistance = 3;
        attackRange = 1;
    }
}
