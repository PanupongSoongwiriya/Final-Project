using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Headache : Character
{
    void Start()
    {
        characterName = "ค้างคาวปีศาจ";
        faction = "Disease";
        classCharacter = "ปวดหัว";

        hp = 50;
        attackPower = 45;
        defensePower = 15;

        startSetUp();

        characterStatus = status.GetComponent<HeadacheStatus>();
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
