using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hammer : Character
{
    void Start()
    {
        characterName = "พลค้อน";
        faction = "Medicine";
        classCharacter = "Atk";
        genusPhase = "ระยะใกล้";

        HP = 4;
        attackPower = 3;
        defensePower = 1;

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
    }
}
