using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DebuffATK : Skill
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
        skillName = "Debuff ATK";
        bonusEffect = -2;
        desCripTion = "ลดพลังโจมตีศัตรู 1 ตัวในระยะการโจมตี\n(-spATK " + Math.Abs(bonusEffect) + ")";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.State = "Debuff with enemies";
            gameSystem.SkillType = "ATK";
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
