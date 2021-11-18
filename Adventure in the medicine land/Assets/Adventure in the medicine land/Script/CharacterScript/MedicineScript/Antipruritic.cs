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
        genusPhase = "ระยะใกล้";


        attackPower = 3;
        defensePower = 1;
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
        attackRange = 2;
        walkingDistance = 2;
    }
    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("อาการคัน"))
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
