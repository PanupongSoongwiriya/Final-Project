using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkinFungus : Character
{
    void Start()
    {
        characterName = "SkinFungus";
        faction = "Disease";
        classCharacter = "เชื้อราที่ผิวหนัง";
        genusPhase = "ระยะกลาง";

        HP = 6;
        attackPower = 1;
        defensePower = 1;


        startSetUp();
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

    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ยาฆ่าเชื้อรา"))
        {
            return 1.5f;
        }
        else if (gameSystem.NowCharecter.classCharacter.Equals("ฮีโร่"))
        {
            return 1.25f;
        }
        else if (gameSystem.NowCharecter.genusPhase.Equals("ระยะกลาง"))
        {
            return 0.5f;
        }
        return 1;
    }
}
