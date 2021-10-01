using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootATK : Skill
{
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        skillName = "Boot ATK";
        bonusEffect = 2;
        desCripTion = "เพิ่มพลังโจมตีให้กับพันธมิตร 1 ตัวในระยะการโจมตี\n(+spATK " + bonusEffect + ")";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.State = "Use skills with ally";
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
