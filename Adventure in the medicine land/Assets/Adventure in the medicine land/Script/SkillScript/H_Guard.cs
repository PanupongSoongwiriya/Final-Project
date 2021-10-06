using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Guard : Skill
{
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        skillName = "H_Guard";
        bonusEffect = 4;
        desCripTion = "เพิ่มพลังป้องกันให้กับตัวเอง(+spDEF " + bonusEffect + ")";
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.NowCharecter.specialDefense += bonusEffect;
            gameSystem.State = "Choose a medicine character";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            gameSystem.NowCharecter.doneIt();
        }
    }
}
