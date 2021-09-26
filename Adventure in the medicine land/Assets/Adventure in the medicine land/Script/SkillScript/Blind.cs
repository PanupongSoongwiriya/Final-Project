using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blind : Skill
{
    void Start()
    {
        skillName = "Blind";
        bonusEffect = -99;
        desCripTion = "เลือกศัตรูในระยะการโจมตี 1 ตัวและทำให้อีกฝ่ายไม่สามาร\nโจมตีได้ 1 เทิร์น";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.State = "Debuff with enemies";
            gameSystem.SkillType = "AR";
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
