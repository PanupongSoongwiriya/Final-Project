using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusclePain : Character
{
    void Start()
    {
        characterName = "MusclePain";
        faction = "Disease";
        classCharacter = "ปวดกล้ามเนื้อ";
        genusPhase = "ระยะกลาง";

        HP = 6;
        attackPower = 1;
        defensePower = 1;

        walkingDistance = 3;
        attackRange = 1;

        startSetUp();
    }

    void OnMouseDown()
    {
        allAction();
    }

    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("แก้ปวดกล้ามเนื้อ"))
        {
            return 1.5f;
        }
        else if (gameSystem.NowCharecter.classCharacter.Equals("Hero"))
        {
            return 1.25f;
        }
        else if (gameSystem.NowCharecter.genusPhase.Equals("ระยะกลาง"))
        {
            return 0.5f;
        }
        return 1;
    }
}
