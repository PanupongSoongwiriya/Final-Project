using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BootSpeed : Skill
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
        skillName = "BootSpeed";
        bonusEffect = 1;
        desCripTion = "เพิ่มระยะการเดินให้กับพันธมิตร 1 ตัวในระยะการโจมตี(+ระยะเดิน " + bonusEffect + ")";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.State = "Use skills with ally";
            gameSystem.SkillType = "WD";
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
