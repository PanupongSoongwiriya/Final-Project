using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Antibiotic : Character
{
    void Start()
    {
        characterName = "Amox";
        faction = "Medicine";
        classCharacter = "ยาฆ่าเชื้อ";
        genusPhase = "ระยะใกล้";

        HP = 4;
        attackPower = 3;
        defensePower = 1;

        walkingDistance = 3;
        attackRange = 1;

        startSetUp();

        allSkill.Add(new HeavyATK(gameSystem));
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ติดเชื้อ"))
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
