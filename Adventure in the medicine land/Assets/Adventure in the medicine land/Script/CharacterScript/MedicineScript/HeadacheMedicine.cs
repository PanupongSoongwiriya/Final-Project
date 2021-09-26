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


        HP = 3;
        attackPower = 1;
        defensePower = 2;


        startSetUp();

        /*GameObject skill = GameObject.Find("SkillList");
        allSkill.Add(skill.GetComponent<HeavyATK>());*/
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected override void resetRange()
    {
        attackRange = 1;
        walkingDistance = 1;
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
