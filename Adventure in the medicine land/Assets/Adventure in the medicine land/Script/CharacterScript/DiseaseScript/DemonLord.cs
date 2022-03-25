using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DemonLord : Character
{
    void Start()
    {
        characterName = "จอมมาร";
        faction = "Disease";
        classCharacter = "จอมมาร";

        hp = 500;
        attackPower = 3;
        defensePower = 3;

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
        walkingDistance = 2;
        attackRange = 2;
    }
    /*
    public override float checkAdvantage(Character actor)
    {
        if (actor.classCharacter.Equals("ฮีโร่"))
        {
            return 1.25f;
        }
        return 1;
    }*/
}
