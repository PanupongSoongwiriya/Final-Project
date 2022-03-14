using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shield_Ax_Man : Character
{
    void Start()
    {
        characterName = "พลขวานโล่";
        faction = "Medicine";
        classCharacter = "Def";
        genusPhase = "ระยะใกล้";
        ClassType = "Tank";


        attackPower = 3;
        defensePower = 1;
        HP = 1;


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
        attackRange = 2;
        walkingDistance = 2;
    }

}
