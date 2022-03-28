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
        classCharacter = "แทงค์";

        hp = 65;
        attackPower = 35;
        defensePower = 20;

        startSetUp();
        ClassType = "Tank";
        
        bag.Add(status.GetComponent<Bandage>());
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
