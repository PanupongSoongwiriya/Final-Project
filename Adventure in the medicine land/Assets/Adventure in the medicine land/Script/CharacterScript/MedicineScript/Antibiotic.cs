using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Antibiotic : Character
{
    void Start()
    {
        characterName = "Hero";
        faction = "Medicine";
        classCharacter = "ยาฆ่าเชื้อ";

        HP = 10;
        attackPower = 2;
        defensePower = 1;

        walkingDistance = 3;
        attackRange = 1;

        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        memberUpdate();
        doneItYet = true;

        allSkill.Add(new HeavyATK(gameSystem));
    }

    void Update()
    {
        resetSP();
    }
    void OnMouseDown()
    {
        showDetailDisease();
        prepare();
        attacked();
    }
    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ติดเชื้อ"))
        {
            return 0.5f;
        }
        return 1;
    }

}
