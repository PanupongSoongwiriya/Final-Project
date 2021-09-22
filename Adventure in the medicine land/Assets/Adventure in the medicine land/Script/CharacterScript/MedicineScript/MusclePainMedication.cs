using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusclePainMedication : Character
{
    void Start()
    {
        characterName = "Uniren";
        faction = "Medicine";
        classCharacter = "ยาแก้ปวดกล้ามเนื้อ";
        genusPhase = "ระยะกลาง";

        attackRange = 2;
        walkingDistance = 2;

        attackPower = 2;
        defensePower = 1;
        HP = 3;


        startSetUp();

        //allSkill.Add(new HeavyATK(gameSystem));
    }

    void OnMouseDown()
    {
        allAction();
    }

    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ปวดกล้ามเนื้อ"))
        {
            return 0.5f;
        }
        else if (gameSystem.NowCharecter.genusPhase.Equals("ระยะกลาง"))
        {
            return 0.75f;
        }
        return 1;
    }

}
