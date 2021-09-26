using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hero : Character
{
    void Start()
    {
        characterName = "Hero";
        faction = "Medicine";
        classCharacter = "ฮีโร่";
        genusPhase = "";


        attackPower = 3;
        defensePower = 3;
        HP = 3;


        startSetUp();

        /*GameObject skill = new GameObject();
        skill.name = name+" Skill";
        skill.AddComponent<DebuffATK>().gameSystem = gameSystem;
        skill.AddComponent<DebuffDEF>().gameSystem = gameSystem;
        allSkill.Add(skill.GetComponent<DebuffATK>());
        allSkill.Add(skill.GetComponent<DebuffDEF>());*/
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected override void resetRange()
    {
        attackRange = 2;
        walkingDistance = 3;
    }

    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("จอมมาร"))
        {
            return 1.0f;
        }
        return 0.75f;
    }

}
