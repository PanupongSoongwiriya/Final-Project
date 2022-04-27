using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusclePain : Character
{
    void Start()
    {
        characterName = "ปูกล้ามโต";
        faction = "Disease";
        classCharacter = "ปวดกล้ามเนื้อ";
        soundAttackType = "Slash";

        hp = 50;
        attackPower = 50;
        defensePower = 10;

        startSetUp();

        characterStatus = status.GetComponent<MusclePainStatus>();
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
