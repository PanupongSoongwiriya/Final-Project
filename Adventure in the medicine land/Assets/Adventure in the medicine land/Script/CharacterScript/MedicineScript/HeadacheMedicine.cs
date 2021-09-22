﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeadacheMedicine : Character
{
    void Start()
    {
        characterName = "Voltaren";
        faction = "Medicine";
        classCharacter = "ยาแก้ปวดหัว";
        genusPhase = "ระยะใกล้";

        attackRange = 1;
        walkingDistance = 1;

        HP = 3;
        attackPower = 1;
        defensePower = 2;


        startSetUp();

        //allSkill.Add(new HeavyATK(gameSystem));
    }

    void OnMouseDown()
    {
        allAction();
    }

    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ปวดหัว"))
        {
            return 0.5f;
        }
        else if (gameSystem.NowCharecter.genusPhase.Equals("ระยะใกล้"))
        {
            return 0.75f;
        }
        return 1;
    }

}
