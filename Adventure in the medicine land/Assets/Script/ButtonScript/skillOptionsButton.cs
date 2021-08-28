using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillOptionsButton : controlPanelButton
{
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for orders"))
        {
            gameSystem.State = "waiting for skill";
            Debug.Log(gameSystem.State);
            switchPanel(true, false, true);//controlPanel, optionsPanel, skillPanel
        }
    }
}
