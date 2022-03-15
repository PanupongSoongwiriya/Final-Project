using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class General : Character
{
    void Start()
    {
        characterName = "นายพล";
        faction = "Medicine";
        classCharacter = "จู่โจม";

        attackPower = 2;
        defensePower = 1;
        HP = 3;

        startSetUp();
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected override void resetRange()
    {
        attackRange = 2;
        walkingDistance = 2;
    }

    void Update()
    {
        moveSmoothly();
        spinToTarget();
    }
}
