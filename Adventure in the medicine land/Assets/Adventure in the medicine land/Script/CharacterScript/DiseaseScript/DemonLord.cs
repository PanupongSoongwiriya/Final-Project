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

        hp = 500;
        attackPower = 3;
        defensePower = 3;

        startSetUp();
    }
    void Update()
    {
        moveSmoothly();
        spinToTarget();
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
