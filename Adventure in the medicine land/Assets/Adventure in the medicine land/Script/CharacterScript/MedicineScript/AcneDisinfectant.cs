using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AcneDisinfectant : Character
{
    void Start()
    {
        characterName = "Benzac";
        faction = "Medicine";
        classCharacter = "ยาฆ่าเชื้อสิว";
        genusPhase = "ระยะใกล้";


        attackPower = 2;
        defensePower = 2;
        HP = 10;


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
        Debug.Log(name + ": resetRange()");
        attackRange = 2;
        walkingDistance = 2;
    }

    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("สิว"))
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
