using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkButton : controlPanelButton
{
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for orders"))
        {
            gameSystem.State = "walk";
            Debug.Log(gameSystem.State);
            switchPanel(true, false, false);//controlPanel, optionsPanel, skillPanel
        }
    }
}
