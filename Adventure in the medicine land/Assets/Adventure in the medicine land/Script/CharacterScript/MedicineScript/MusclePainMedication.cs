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


        attackPower = 2;
        defensePower = 1;
        HP = 3;


        startSetUp();

        GameObject skill = GameObject.Find("SkillList");
        allSkill.Add(skill.GetComponent<DebuffATK>());
        allSkill.Add(skill.GetComponent<DebuffDEF>());
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected override void resetRange()
    {
        attackRange = 2;
        walkingDistance = 2;
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
