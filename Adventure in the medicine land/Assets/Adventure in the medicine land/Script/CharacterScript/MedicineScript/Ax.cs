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
        classCharacter = "จู่โจม";

        hp = 55;
        attackPower = 45;
        defensePower = 10;
        
        startSetUp();
        
        bag.Add(status.GetComponent<Bandage>());
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
        walkingDistance = 3;
    }

}
