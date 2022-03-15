using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Headache : Character
{
    void Start()
    {
        characterName = "ค้างคาวปีศาจ";
        faction = "Disease";
        classCharacter = "ปวดหัว";

        HP = 6;
        attackPower = 1;
        defensePower = 1;


        startSetUp();

        characterStatus = status.GetComponent<HeadacheStatus>();
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
        if (actor.classCharacter.Equals("ยาแก้ปวดหัว"))
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
