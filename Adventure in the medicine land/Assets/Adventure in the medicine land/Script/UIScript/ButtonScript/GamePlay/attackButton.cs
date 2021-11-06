using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackButton : controlPanelButton
{
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for orders") && ActiveBotton)
        {
            tutorialPlus();
            gameSystem.State = "Choose a enemy character";
            switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
}
