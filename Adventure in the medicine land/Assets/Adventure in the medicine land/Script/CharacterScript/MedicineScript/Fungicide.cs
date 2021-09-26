using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fungicide : Character
{
    void Start()
    {
        characterName = "Tonaf";
        faction = "Medicine";
        classCharacter = "ยาฆ่าเชื้อรา";
        genusPhase = "ระยะกลาง";


        attackPower = 0;
        defensePower = 0;
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
        attackRange = 0;
        walkingDistance = 0;
    }

    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("เชื้อราที่ผิวหนัง"))
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
