using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BloodTonic : Character
{
    void Start()
    {
        characterName = "Folic";
        faction = "Medicine";
        classCharacter = "ยาฆ่าเชื้อรา";
        genusPhase = "ระยะไกล";

        attackRange = 3;
        walkingDistance = 2;

        attackPower = 2;
        defensePower = 1;
        HP = 2;


        startSetUp();

        //allSkill.Add(new HeavyATK(gameSystem));
    }

    void OnMouseDown()
    {
        allAction();
    }
}
