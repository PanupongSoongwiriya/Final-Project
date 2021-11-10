using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelButton : controlPanelButton
{
    public override void changeState()
    {
        activeBotton = alpha == 1;
        if (ActiveBotton)
        {
            if (gameSystem.State.Equals("waiting for orders") || gameSystem.State.Equals("Choose a medicine character"))
            {
                tutorialPlus();
                gameSystem.State = "Choose a medicine character";
                switchPanel(false, true, false, false, false);
                //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            }
            else if (gameSystem.State.Equals("walk") || gameSystem.State.Equals("Choose a enemy character") || gameSystem.State.Equals("waiting for skill"))
            {
                tutorialPlus();
                gameSystem.State = "waiting for orders";
                switchPanel(true, true, false, true, false);
                //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            }
            else if (gameSystem.State.Equals("Use skills with enemies") || gameSystem.State.Equals("Use skills with ally") || gameSystem.State.Equals("Debuff with enemies"))
            {
                tutorialPlus();
                gameSystem.State = "waiting for skill";
                gameSystem.NowCharecter.allSkill[gameSystem.NowCharecter.indexSkill].cancelSkill();
                switchPanel(true, false, true, false, true);
                //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            }
        }
    }
}