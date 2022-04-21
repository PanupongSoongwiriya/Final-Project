using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stomachache : Character
{
    void Start()
    {
        characterName = "มังกรพิษ";
        faction = "Disease";
        classCharacter = "ปวดท้อง";

        hp = 60;
        attackPower = 40;
        defensePower = 20;

        startSetUp();

        characterStatus = status.GetComponent<StomachacheStatus>();
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