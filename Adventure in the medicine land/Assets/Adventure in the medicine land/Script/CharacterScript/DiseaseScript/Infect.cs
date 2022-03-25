using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Infect : Character
{
    void Start()
    {
        characterName = "ปีศาจไวรัส";
        faction = "Disease";
        classCharacter = "ติดเชื้อ";

        hp = 45;
        attackPower = 60;
        defensePower = 5;

        startSetUp();

        characterStatus = status.GetComponent<InfectStatus>();
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
        if (actor.classCharacter.Equals("ยาฆ่าเชื้อ"))
        {
            return 1.5f;
        }
        else if (actor.classCharacter.Equals("ฮีโร่"))
        {
            return 1.25f;
        }
        else if (actor.genusPhase.Equals("ระยะใกล้"))
        {
            return 0.5f;
        }
        return 1;
    }*/

    
}
