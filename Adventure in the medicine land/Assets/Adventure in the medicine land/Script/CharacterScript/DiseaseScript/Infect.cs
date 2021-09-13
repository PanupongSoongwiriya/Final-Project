using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Infect : Character
{
    void Start()
    {
        characterName = "Villain";
        faction = "Disease";
        classCharacter = "ติดเชื้อ";

        HP = 4;
        attackPower = 1;
        defensePower = 1;

        walkingDistance = 3;
        attackRange = 1;

        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        memberUpdate();
        doneItYet = true;
    }

    void Update()
    {
        resetSP();
    }
    void OnMouseDown()
    {
        setPositionCamera();
        showDetailDisease();
        prepare();
        attacked();
    }
    protected override float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("ยาฆ่าเชื้อ"))
        {
            return 1.5f;
        }
        return 1;

    }

    
}
