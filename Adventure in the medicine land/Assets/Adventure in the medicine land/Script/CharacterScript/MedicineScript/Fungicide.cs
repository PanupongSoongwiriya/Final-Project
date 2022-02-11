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
        genusPhase = "ระยะใกล้";


        attackPower = 0;
        defensePower = 0;
        HP = 1;


        startSetUp();

        /*allSkill.Add(skill.GetComponent<HeavyATK>());*/
    }

    void Update()
    {
        moveSmoothly();
        spinToTarget();
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

    /*
    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("เชื้อราที่ผิวหนัง"))
        {
            return 0.5f;
        }
        else if (actor.genusPhase.Equals("ระยะกลาง"))
        {
            return 0.75f;
        }
        return 1;
    }*/

}
