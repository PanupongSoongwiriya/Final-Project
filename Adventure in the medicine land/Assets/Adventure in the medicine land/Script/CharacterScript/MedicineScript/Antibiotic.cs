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
        walkingDistance = 3;
        attackRange = 1;
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
