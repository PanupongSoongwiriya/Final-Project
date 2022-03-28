using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Archer : Character
{
    void Start()
    {
        characterName = "พลธนู";
        faction = "Medicine";
        classCharacter = "จู่โจม(ธนู)";
        
        hp = 45;
        attackPower = 50;
        defensePower = 15;

        startSetUp();
        
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
        attackRange = 2;
    }

}
