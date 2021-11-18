using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RunnyNose : Character
{
    void Start()
    {
        characterName = "RunnyNose";
        faction = "Disease";
        classCharacter = "น้ำมูกไหล";
        genusPhase = "ระยะใกล้";

        HP = 6;
        attackPower = 1;
        defensePower = 1;


        startSetUp();
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
    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("ยาลดน้ำมูก"))
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
    }


}
