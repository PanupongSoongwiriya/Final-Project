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
        classCharacter = "ยาบำรุงเลือด";
        genusPhase = "ระยะไกล";


        attackPower = 2;
        defensePower = 1;
        HP = 2;


        startSetUp();

        GameObject skill = GameObject.Find("SkillList");
        allSkill.Add(skill.GetComponent<Heal>());
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected override void resetRange()
    {
        attackRange = 3;
        walkingDistance = 2;
    }
}
