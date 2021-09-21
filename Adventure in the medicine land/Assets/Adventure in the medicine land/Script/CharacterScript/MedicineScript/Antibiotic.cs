using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Antibiotic : Character
{
    void Start()
    {
        characterName = "Amox";
        faction = "Medicine";
        classCharacter = "ยาฆ่าเชื้อ";
        genusPhase = "ระยะใกล้";

        HP = 10;
        attackPower = 3;
        defensePower = 1;

        walkingDistance = 3;
        attackRange = 1;

        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        gameSystem.memberUpdate(this);
        doneItYet = true;

        allSkill.Add(new HeavyATK(gameSystem));
    }

    void Update()
    {
        //resetSP();
    }
    void OnMouseDown()
    {
        showDetailDisease();
        prepare();
        attacked();
        checkBuffDebuff();
    }
    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ติดเชื้อ"))
        {
            return 0.5f;
        }
        else if (gameSystem.NowCharecter.genusPhase.Equals("ระยะใกล้"))
        {
            return 0.5f;
        }
        return 1;
    }

}
