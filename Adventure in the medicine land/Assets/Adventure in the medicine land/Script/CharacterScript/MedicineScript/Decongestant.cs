using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Decongestant : Character
{
    void Start()
    {
        characterName = "Zyrtec";
        faction = "Medicine";
        classCharacter = "ยาลดน้ำมูก";
        genusPhase = "ระยะใกล้";


        HP = 3;
        attackPower = 1;
        defensePower = 2;


        startSetUp();

        /*allSkill.Add(skill.GetComponent<HeavyATK>());*/
    }

    void Update()
    {
        moveSmoothly();
    }
    void OnMouseDown()
    {
        allAction();
    }
    protected override void resetRange()
    {
        attackRange = 1;
        walkingDistance = 1;
    }

    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("น้ำมูกไหล"))
        {
            return 0.5f;
        }
        else if (actor.genusPhase.Equals("ระยะใกล้"))
        {
            return 0.75f;
        }
        return 1;
    }

}
