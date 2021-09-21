using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyATK : Skill
{
    public HeavyATK(GameSystem gs)
    {
        gameSystem = gs;
        skillName = "Heavy ATK";
        desCripTion = "เลือกศัตรูในระยะการโจมตี\n1 ตัวเพื่อสร้างความเสียหาย\nแบบพิเศษ(+spAtk 1)";
        bonusEffect = 1;
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
