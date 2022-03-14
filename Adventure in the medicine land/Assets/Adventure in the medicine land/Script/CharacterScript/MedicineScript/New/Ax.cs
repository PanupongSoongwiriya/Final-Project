using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ax : Character
{
    void Start()
    {
        characterName = "พลขวาน";
        faction = "Medicine";
        classCharacter = "Atk";
        genusPhase = "ระยะใกล้";


        HP = 3;
        attackPower = 2;
        defensePower = 2;


        startSetUp();
    }

    void OnMouseDown()
    {
        allAction();
    }

    void Update()
    {
        moveSmoothly();
        spinToTarget();
    }
    protected override void resetRange()
    {
        attackRange = 1;
        walkingDistance = 2;
    }

}
