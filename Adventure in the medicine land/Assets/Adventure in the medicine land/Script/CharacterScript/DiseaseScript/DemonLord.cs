using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DemonLord : Character
{
    void Start()
    {
        characterName = "จอมมารโควิด";
        faction = "Disease";
        classCharacter = "จอมมาร";
        genusPhase = "";

        HP = 500;
        attackPower = 3;
        defensePower = 3;


        startSetUp();
    }

    void OnMouseDown()
    {
        allAction();
    }

    protected override void resetRange()
    {
        walkingDistance = 3;
        attackRange = 3;
    }
    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ฮีโร่"))
        {
            return 1.25f;
        }
        return 1;
    }
}
