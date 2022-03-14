using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Doctor : Character
{
    void Start()
    {
        characterName = "หมอ";
        faction = "Medicine";
        classCharacter = "Sup";
        genusPhase = "ระยะไกล";

        attackPower = 2;
        defensePower = 1;
        HP = 2;

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
        attackRange = 3;
        walkingDistance = 2;
    }
}
