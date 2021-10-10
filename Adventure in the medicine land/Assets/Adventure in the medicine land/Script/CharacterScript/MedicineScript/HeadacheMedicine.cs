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

        /*allSkill.Add(skill.GetComponent<HeavyATK>());*/
        allSkill.Add(skill.GetComponent<H_Guard>());
        allSkill.Add(skill.GetComponent<PoisonKnife>());
        allSkill.Add(skill.GetComponent<BrokenArmor>());
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
        attackRange = 1;
        walkingDistance = 1;
    }

    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("ปวดหัว"))
        {
            return 0.5f;
        }
        else if (actor.genusPhase.Equals("ระยะใกล้"))
        {
            return 0.75f;
        }
        return 1;
    }

}
