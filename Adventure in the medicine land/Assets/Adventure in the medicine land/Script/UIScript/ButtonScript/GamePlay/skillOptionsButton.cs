using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillOptionsButton : controlPanelButton
{
    public GameObject SkillPanel;
    public override void changeState()
    {
        activeBotton = alpha == 1;
        if (gameSystem.State.Equals("waiting for orders") && ActiveBotton)
        {
            tutorialPlus();
            gameSystem.State = "waiting for skill";
            SkillPanel.GetComponent<SkillPanel>().numberOfSkill = gameSystem.NowCharecter.allSkill.Count;
            SkillPanel.GetComponent<SkillPanel>().gameSystem = gameSystem;
            skillDetailPanel.GetComponent<SkillDetailPanel>().numberOfSkill = gameSystem.NowCharecter.allSkill.Count;
            skillDetailPanel.GetComponent<SkillDetailPanel>().gameSystem = gameSystem;
            switchPanel(true, false, true, false, true);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
}
