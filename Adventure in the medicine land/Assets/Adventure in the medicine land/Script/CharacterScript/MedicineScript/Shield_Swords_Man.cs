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
        classCharacter = "แทงค์";
        soundAttackType = "Slash";

        hp = 70;
        attackPower = 30;
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
        attackRange = 1;
        walkingDistance = 2;
    }

}
