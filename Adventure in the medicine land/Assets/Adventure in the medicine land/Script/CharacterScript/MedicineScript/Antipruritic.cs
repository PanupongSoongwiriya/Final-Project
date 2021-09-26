using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Antipruritic : Character
{
    void Start()
    {
        characterName = "Kela";
        faction = "Medicine";
        classCharacter = "ยาแก้คัน";
        genusPhase = "ระยะกลาง";


        attackPower = 3;
        defensePower = 1;
        HP = 1;


        startSetUp();

        /*GameObject skill = new GameObject();
        skill.name = name+" Skill";
        skill.AddComponent<HeavyATK>().gameSystem = gameSystem;
        allSkill.Add(skill.GetComponent<HeavyATK>());*/
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
        if (gameSystem.NowCharecter.classCharacter.Equals("อาการคัน"))
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
