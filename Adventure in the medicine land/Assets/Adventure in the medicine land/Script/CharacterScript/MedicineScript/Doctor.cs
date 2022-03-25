using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Doctor : Character
{
    void Start()
    {
        characterName = "โฮพ";
        faction = "Medicine";
        classCharacter = "หมอ";

        hp = 50;
        attackPower = 30;
        defensePower = 10;
        

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
        attackRange = 1;
        walkingDistance = 3;
        cureRange = 2;
    }
}
