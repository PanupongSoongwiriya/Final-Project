using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AcneDisinfectant : Character
{
    void Start()
    {
        characterName = "Benzac";
        faction = "Medicine";
        classCharacter = "ยาฆ่าเชื้อสิว";
        genusPhase = "ระยะกลาง";

        attackRange = 2;
        walkingDistance = 2;

        attackPower = 2;
        defensePower = 2;
        HP = 2;


        startSetUp();

        //allSkill.Add(new HeavyATK(gameSystem));
    }

    void OnMouseDown()
    {
        allAction();
    }

    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("สิว"))
        {
            return 0.5f;
        }
        else if (gameSystem.NowCharecter.genusPhase.Equals("ระยะกลาง"))
        {
            return 0.75f;
        }
        return 1;
    }

}
