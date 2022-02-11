using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusclePain : Character
{
    void Start()
    {
        characterName = "MusclePain";
        faction = "Disease";
        classCharacter = "ปวดกล้ามเนื้อ";
        genusPhase = "ระยะกลาง";

        HP = 6;
        attackPower = 1;
        defensePower = 1;

        startSetUp();

        characterStatus = status.GetComponent<MusclePainStatus>();
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

    /*public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("ยาแก้ปวดกล้ามเนื้อ"))
        {
            return 1.5f;
        }
        else if (actor.classCharacter.Equals("ฮีโร่"))
        {
            return 1.25f;
        }
        else if (actor.genusPhase.Equals("ระยะกลาง"))
        {
            return 0.5f;
        }
        return 1;
    }*/
}
