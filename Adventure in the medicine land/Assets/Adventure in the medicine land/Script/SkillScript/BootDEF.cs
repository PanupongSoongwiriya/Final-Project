using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootDEF : Skill
{
    public BootDEF(GameSystem gs)
    {
        gameSystem = gs;
        skillName = "Boot DEF";
        bonusEffect = 2;
        desCripTion = "เพิ่มพลังป้องกันให้กับพันธมิตร 1 ตัวในระยะการโจมตี\n(+spDEF " + bonusEffect + ")";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.State = "Use skills with ally";
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
