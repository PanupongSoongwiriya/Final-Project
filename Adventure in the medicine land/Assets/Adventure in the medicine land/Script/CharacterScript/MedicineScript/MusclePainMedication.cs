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
        genusPhase = "ระยะใกล้";


        attackPower = 2;
        defensePower = 1;
        HP = 3;


        startSetUp();

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

    void Update()
    {
        moveSmoothly();
        spinToTarget();
    }
    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("ปวดกล้ามเนื้อ"))
        {
            return 0.5f;
        }
        else if (actor.genusPhase.Equals("ระยะกลาง"))
        {
            return 0.75f;
        }
        return 1;
    }

}
