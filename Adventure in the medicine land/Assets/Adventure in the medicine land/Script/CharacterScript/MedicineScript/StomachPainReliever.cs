﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StomachPainReliever : Character
{
    void Start()
    {
        characterName = "Gavis";
        faction = "Medicine";
        classCharacter = "ยาแก้ปวดท้อง";
        genusPhase = "ระยะใกล้";

        attackRange = 1;
        walkingDistance = 2;

        HP = 3;
        attackPower = 2;
        defensePower = 2;


        startSetUp();

        allSkill.Add(new HeavyATK(gameSystem));
    }

    void OnMouseDown()
    {
        allAction();
    }

    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ปวดท้อง"))
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
