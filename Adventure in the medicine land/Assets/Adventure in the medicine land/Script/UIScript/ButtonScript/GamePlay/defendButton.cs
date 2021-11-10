using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defendButton : controlPanelButton
{
    public override void changeState()
    {
        activeBotton = alpha == 1;
        if (gameSystem.State.Equals("waiting for orders") && ActiveBotton)
        {
            tutorialPlus();
            gameSystem.NowCharecter.specialDefense += 1;
            gameSystem.State = "Choose a medicine character";
            switchPanel(false, true, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            gameSystem.NowCharecter.doneIt();
        }
    }
}
