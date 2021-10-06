using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoisonKnife : Skill
{
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        skillName = "Poison Knife";
        bonusEffect = 1;
        bonusEffect_2 = -1;
        desCripTion = "เลือกศัตรูในระยะการโจมตี 1 ตัวเพื่อสร้างความเสียหายแบบพิเศษ(+spATK " + bonusEffect + ") และ ลดพลังป้องกันศัตรู(-spDEF " + Math.Abs(bonusEffect_2) + ")";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.NowCharecter.specialAttack += bonusEffect;
            gameSystem.State = "Debuff with enemies";
            gameSystem.SkillType = "ATK/DEF";
            gameSystem.SkillBonusEffect = bonusEffect_2;
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
    public override void cancelSkill()
    {
        gameSystem.NowCharecter.specialAttack -= bonusEffect;
    }
}
