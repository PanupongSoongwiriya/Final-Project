using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DebuffATK : Skill
{
    public DebuffATK(GameSystem gs)
    {
        gameSystem = gs;
        skillName = "Debuff ATK";
        bonusEffect = -2;
        desCripTion = "ลดพลังโจมตีศัตรู 1 ตัวในระยะการโจมตี\n(-spAtk " + Math.Abs(bonusEffect) + ")";
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
