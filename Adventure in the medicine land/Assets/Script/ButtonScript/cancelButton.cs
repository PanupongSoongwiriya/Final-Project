using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelButton : controlPanelButton
{
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for orders"))
        {
            gameSystem.State = "Choose a player character";
            Debug.Log(gameSystem.State);
            switchPanel(false, true, false);//controlPanel, optionsPanel, skillPanel
        }
        else if (gameSystem.State.Equals("walk") || gameSystem.State.Equals("Choose a enemy character") || gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.State = "waiting for orders";
            Debug.Log(gameSystem.State);
            switchPanel(true, true, false);//controlPanel, optionsPanel, skillPanel
        }
    }
}
