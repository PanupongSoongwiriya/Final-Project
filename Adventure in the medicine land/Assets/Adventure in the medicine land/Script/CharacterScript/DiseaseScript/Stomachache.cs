using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stomachache : Character
{
    void Start()
    {
        characterName = "Stomachache";
        faction = "Disease";
        classCharacter = "ปวดท้อง";
        genusPhase = "ระยะใกล้";

        HP = 6;
        attackPower = 1;
        defensePower = 1;

        walkingDistance = 3;
        attackRange = 1;

        startSetUp();
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("แก้ปวดท้อง"))
        {
            return 1.5f;
        }
        else if (gameSystem.NowCharecter.classCharacter.Equals("Hero"))
        {
            return 1.25f;
        }
        else if (gameSystem.NowCharecter.genusPhase.Equals("ระยะใกล้"))
        {
            return 0.5f;
        }
        return 1;
    }


}
