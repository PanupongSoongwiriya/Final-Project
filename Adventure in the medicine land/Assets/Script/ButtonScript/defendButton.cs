using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defendButton : controlPanelButton
{

    public override void changeState()
    {
        gameSystem.NowCharecter.doneIt();
        if (gameSystem.State.Equals("waiting for orders"))
        {
            gameSystem.NowCharecter.specialDefense += 1;
            gameSystem.State = "Choose a medicine character";
            Debug.Log(gameSystem.NowCharecter.specialDefense);
            switchPanel(false, true, false);//controlPanel, optionsPanel, skillPanel
        }
    }
}
