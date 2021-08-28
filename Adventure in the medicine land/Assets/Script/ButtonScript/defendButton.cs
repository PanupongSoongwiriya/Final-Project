using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defendButton : controlPanelButton
{

    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for orders"))
        {
            gameSystem.Player.specialDefense += 1;
            gameSystem.State = "Choose a player character";
            Debug.Log(gameSystem.State);
            Debug.Log(gameSystem.Player.specialDefense);
            switchPanel(false, true, false);//controlPanel, optionsPanel, skillPanel
        }
    }
}
