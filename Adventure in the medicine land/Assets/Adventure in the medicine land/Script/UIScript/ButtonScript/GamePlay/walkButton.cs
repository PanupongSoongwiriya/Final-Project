using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkButton : controlPanelButton
{
    public override void changeState()
    {
        activeBotton = c == 1;
        if (gameSystem.State.Equals("waiting for orders") & ActiveBotton & !gameSystem.NowCharecter.disableMove)
        {
            ConfirmAudio.Play();
            tutorialPlus();
            gameSystem.State = "walk";
            switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
}
