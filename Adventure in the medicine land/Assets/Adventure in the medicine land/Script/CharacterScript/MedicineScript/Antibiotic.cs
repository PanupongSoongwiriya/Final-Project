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
        classCharacter = "Antibiotic";

        HP = 10;

        attackPower = 2;
        defensePower = 1;

        walkingDistance = 3;
        attackRange = 1;


        gameSystem = system.GetComponent<GameSystem>();
        memberUpdate();
        doneItYet = true;

        allSkill.Add(new HeavyATK());
    }

    void Update()
    {
        resetSP();
    }
    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("Infect"))
        {
            return 0.5f;
        }
        return 1;
        
    }

    void OnMouseDown()
    {
        showDetailDisease();
        prepare();
        attacked();
    }
}
