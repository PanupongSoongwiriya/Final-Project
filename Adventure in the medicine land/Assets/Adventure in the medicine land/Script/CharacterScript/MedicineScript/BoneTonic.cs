using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoneTonic : Character
{
    void Start()
    {
        characterName = "Fotrate";
        faction = "Medicine";
        classCharacter = "ยาบำรุงกระดูก";
        genusPhase = "ระยะไกล";


        attackPower = 1;
        defensePower = 3;
        HP = 4;


        startSetUp();

        //allSkill.Add(new HawkEye(gameSystem));
    }

    void OnMouseDown()
    {
        allAction();
    }

    protected override void resetRange()
    {
        attackRange = 1;
        walkingDistance = 2;
    }
}
