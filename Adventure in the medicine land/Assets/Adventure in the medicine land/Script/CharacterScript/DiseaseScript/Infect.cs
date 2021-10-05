﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Infect : Character
{
    void Start()
    {
        characterName = "Infect";
        faction = "Disease";
        classCharacter = "ติดเชื้อ";
        genusPhase = "ระยะใกล้";

        HP = 6;
        attackPower = 1;
        defensePower = 1;


        startSetUp();
    }
    void Update()
    {
        moveSmoothly();
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
    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ยาฆ่าเชื้อ"))
        {
            return 1.5f;
        }
        else if (gameSystem.NowCharecter.classCharacter.Equals("ฮีโร่"))
        {
            return 1.25f;
        }
        else if (gameSystem.NowCharecter.genusPhase.Equals("ระยะใกล้"))
        {
            return 0.5f;
        }
        return 1;
    }

    
}
