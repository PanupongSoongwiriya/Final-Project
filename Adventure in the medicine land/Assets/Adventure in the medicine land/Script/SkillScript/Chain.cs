using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chain : Skill
{
    public Chain(GameSystem gs)
    {
        gameSystem = gs;
        skillName = "Chain";
        bonusEffect = -99;
        desCripTion = "ตรึงศัตรูในระยะการโจมตี 1 ตัวและทำให้อีกฝ่ายไม่สามาร\nเคลื่อนไหวได้ 1 เทิร์น";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.State = "Debuff with enemies";
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
