using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkButton : controlPanelButton
{
    public override void changeState()
    {
        activeBotton = alpha == 1;
        if (gameSystem.State.Equals("waiting for orders") && ActiveBotton)
        {
            tutorialPlus();
            gameSystem.State = "walk";
            switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
}
