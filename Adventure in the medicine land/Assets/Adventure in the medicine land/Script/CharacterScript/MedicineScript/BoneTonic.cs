using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoneTonic : Character
{
    void Start()
    {
        characterName = "Fotrate";
        faction = "Medicine";
        classCharacter = "ยาบำรุงกระดูก";

        attackPower = 1;
        defensePower = 3;
        HP = 4;

        startSetUp();

        /*allSkill.Add(skill.GetComponent<HeavyATK>());*/
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
