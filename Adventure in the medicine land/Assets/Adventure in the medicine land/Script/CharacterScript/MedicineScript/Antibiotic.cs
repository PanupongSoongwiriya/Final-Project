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
        genusPhase = "ระยะกลาง";

        HP = 4;
        attackPower = 3;
        defensePower = 1;


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
        walkingDistance = 3;
        attackRange = 1;
    }
    /*
    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("ติดเชื้อ"))
        {
            return 0.5f;
        }
        else if (actor.genusPhase.Equals("ระยะใกล้"))
        {
            return 0.75f;
        }
        return 1;
    }*/

}
