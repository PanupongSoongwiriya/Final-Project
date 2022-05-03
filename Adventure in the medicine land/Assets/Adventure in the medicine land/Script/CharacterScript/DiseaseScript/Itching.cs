using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Itching : Character
{
    void Start()
    {
        characterName = "เต่าสไลม์";
        faction = "Disease";
        classCharacter = "อาการคัน";
        soundAttackType = "Blow";

        hp = 65;
        attackPower = 30;
        defensePower = 25;

        startSetUp();

        characterStatus = status.GetComponent<ItchingStatus>();
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
        walkingDistance = 2;
        attackRange = 1;
    }
}
