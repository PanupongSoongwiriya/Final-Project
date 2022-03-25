using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hammer : Character
{
    void Start()
    {
        characterName = "พลค้อน";
        faction = "Medicine";
        classCharacter = "จู่โจม";

        hp = 55;
        attackPower = 40;
        defensePower = 15;

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
        walkingDistance = 3;
        attackRange = 1;
    }
}
