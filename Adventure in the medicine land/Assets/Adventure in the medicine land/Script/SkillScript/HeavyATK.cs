using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeavyATK : Skill
{
    void Start()
    {
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }
        skillName = "Heavy ATK";
        bonusEffect = 2;
        desCripTion = "เลือกศัตรูในระยะการโจมตี 1 ตัวเพื่อสร้าง\nความเสียหายแบบพิเศษ(+spATK " + bonusEffect + ")";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.NowCharecter.SP_Atk += bonusEffect;
            gameSystem.State = "Use skills with enemies";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
    public override void cancelSkill()
    {
        gameSystem.NowCharecter.SP_Atk -= bonusEffect;
    }
}
