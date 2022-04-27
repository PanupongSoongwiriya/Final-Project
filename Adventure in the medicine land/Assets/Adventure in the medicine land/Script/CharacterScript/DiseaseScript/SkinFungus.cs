using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkinFungus : Character
{
    void Start()
    {
        characterName = "แมงมุมยักษ์";
        faction = "Disease";
        classCharacter = "เชื้อราที่ผิวหนัง";
        soundAttackType = "Blow";

        hp = 45;
        attackPower = 55;
        defensePower = 10;

        startSetUp();

        characterStatus = status.GetComponent<SkinFungusStatus>();
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
        walkingDistance = 3;
        attackRange = 1;
    }
}
