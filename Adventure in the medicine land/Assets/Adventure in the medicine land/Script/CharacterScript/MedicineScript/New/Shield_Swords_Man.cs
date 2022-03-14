using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shield_Swords_Man : Character
{
    void Start()
    {
        characterName = "พลดาบโล่";
        faction = "Medicine";
        classCharacter = "Def";
        genusPhase = "ระยะใกล้";
        ClassType = "Tank";


        attackPower = 2;
        defensePower = 2;
        HP = 10;


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
