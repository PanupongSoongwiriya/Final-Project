using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Archer : Character
{
    void Start()
    {
        characterName = "พลธนู";
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
