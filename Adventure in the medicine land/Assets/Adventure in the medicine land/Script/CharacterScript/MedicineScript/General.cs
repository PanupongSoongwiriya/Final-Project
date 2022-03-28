using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class General : Character
{
    void Start()
    {
        characterName = "นายพล";
        faction = "Medicine";
        classCharacter = "จู่โจม";

        hp = 50;
        attackPower = 40;
        defensePower = 20;

        startSetUp();
        
        bag.Add(status.GetComponent<Bandage>());
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

    void Update()
    {
        moveSmoothly();
        spinToTarget();
    }
}
