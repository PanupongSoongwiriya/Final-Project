using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sniper : Character
{
    void Start()
    {
        characterName = "พลซุ่มยิง";
        faction = "Medicine";
        classCharacter = "จู่โจม(ธนู)";

        HP = 3;
        attackPower = 1;
        defensePower = 2;


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
        walkingDistance = 1;
    }

}
