﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Acne : Character
{
    void Start()
    {
        characterName = "สไลม์";
        faction = "Disease";
        classCharacter = "สิว";

        hp = 75;
        attackPower = 25;
        defensePower = 20;

        startSetUp();

        characterStatus = status.GetComponent<AcneStatus>();
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
    /*
    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("ยาฆ่าเชื้อสิว"))
        {
            return 1.5f;
        }
        else if (actor.classCharacter.Equals("ฮีโร่"))
        {
            return 1.25f;
        }
        else if (actor.genusPhase.Equals("ระยะกลาง"))
        {
            return 0.5f;
        }
        return 1;
    }*/


}
