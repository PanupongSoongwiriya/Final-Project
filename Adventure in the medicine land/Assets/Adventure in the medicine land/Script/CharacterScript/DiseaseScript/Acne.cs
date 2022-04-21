using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Acne : Character
{
    void Start()
    {
        characterName = "สไลม์";
        faction = "Disease";
        classCharacter = "สิว";

        hp = 75;
        attackPower = 25;
        defensePower = 20;

        startSetUp();

        characterStatus = status.GetComponent<AcneStatus>();
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
