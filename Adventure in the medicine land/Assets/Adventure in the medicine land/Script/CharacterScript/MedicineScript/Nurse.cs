using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : Character
{
    void Start()
    {
        characterName = "พยาบาล";
        faction = "Medicine";
        classCharacter = "หมอ";

        hp = 40;
        attackPower = 35;
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
        cureRange = 2;
    }
}
