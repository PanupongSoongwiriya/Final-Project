using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DemonLord : Character
{
    void Start()
    {
        characterName = "จอมมาร";
        faction = "Disease";
        classCharacter = "จอมมาร";
        soundAttackType = "Slash";

        hp = 300;
        attackPower = 45;
        defensePower = 15;

        startSetUp();
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
        walkingDistance = 1;
        attackRange = 2;
    }
}
