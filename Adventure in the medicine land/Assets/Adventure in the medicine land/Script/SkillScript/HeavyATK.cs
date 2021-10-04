using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyATK : Skill
{
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        skillName = "Heavy ATK";
        bonusEffect = 1;
        desCripTion = "เลือกศัตรูในระยะการโจมตี 1 ตัวเพื่อสร้าง\nความเสียหายแบบพิเศษ(+spATK " + bonusEffect + ")";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.NowCharecter.specialAttack += bonusEffect;
            gameSystem.State = "Use skills with enemies";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
    public override void cancelSkill()
    {
        gameSystem.NowCharecter.specialAttack -= bonusEffect;
    }
}
