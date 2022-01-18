using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelButton : controlPanelButton
{
    public GameObject useButton;
    public override void changeState()
    {
        useButton.SetActive(false);
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
            else if (gameSystem.State.Equals("walk") || gameSystem.State.Equals("Choose a enemy character") || gameSystem.State.Equals("waiting for choose medicine"))
            {
                tutorialPlus();
                gameSystem.State = "waiting for orders";
                switchPanel(true, true, false, true, false);
                //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            }
            else if (gameSystem.State.Equals("Use medicine with ally") )
            {
                tutorialPlus();
                gameSystem.State = "waiting for choose medicine";
                gameSystem.selectedMedicine = null;
                useButton.SetActive(true);
                //gameSystem.NowCharecter.allSkill[gameSystem.NowCharecter.indexSkill].cancelSkill();
                switchPanel(true, false, true, false, true);
                //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            }
        }
    }
}
