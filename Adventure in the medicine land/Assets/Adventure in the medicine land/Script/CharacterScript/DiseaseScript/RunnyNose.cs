using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RunnyNose : Character
{
    void Start()
    {
        characterName = "พืชกินคน";
        faction = "Disease";
        classCharacter = "น้ำมูกไหล";

        hp = 65;
        attackPower = 35;
        defensePower = 20;

        startSetUp();

        characterStatus = status.GetComponent<RunnyNoseStatus>();
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
        walkingDistance = 2;
        attackRange = 1;
    }
}
