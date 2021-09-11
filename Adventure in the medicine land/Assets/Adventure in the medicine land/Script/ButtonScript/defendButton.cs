using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defendButton : controlPanelButton
{
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for orders"))
        {
            gameSystem.NowCharecter.specialDefense += 1;
            gameSystem.State = "Choose a medicine character";
            Debug.Log(gameSystem.NowCharecter.specialDefense);
            switchPanel(false, true, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            gameSystem.NowCharecter.doneIt();
        }
    }
}
