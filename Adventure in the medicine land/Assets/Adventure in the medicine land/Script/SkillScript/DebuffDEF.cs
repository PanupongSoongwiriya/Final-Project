using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DebuffDEF : Skill
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
        skillName = "Debuff DEF";
        bonusEffect = -2;
        desCripTion = "ลดพลังป้องกันศัตรู 1 ตัวในระยะการโจมตี\n(-spDEF " + Math.Abs(bonusEffect) + ")";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.State = "Debuff with enemies";
            gameSystem.SkillType = "DEF";
            gameSystem.SkillBonusEffect = bonusEffect;
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
    public override void cancelSkill()
    {
        gameSystem.SkillType = "";
        gameSystem.SkillBonusEffect = 0;
    }
}
