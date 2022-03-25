using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusclePain : Character
{
    void Start()
    {
        characterName = "ปูกล้ามโต";
        faction = "Disease";
        classCharacter = "ปวดกล้ามเนื้อ";

        hp = 50;
        attackPower = 50;
        defensePower = 10;

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
