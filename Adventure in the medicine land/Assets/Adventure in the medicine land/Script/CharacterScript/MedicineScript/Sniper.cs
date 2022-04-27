using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sniper : Character
{
    void Start()
    {
        characterName = "พลซุ่มยิง";
        faction = "Medicine";
        classCharacter = "จู่โจม(ธนู)";
        soundAttackType = "Crossbow";

        hp = 40;
        attackPower = 50;
        defensePower = 10;
        
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
        attackRange = 3;
    }

}
