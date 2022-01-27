using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackButton : controlPanelButton
{
    public override void changeState()
    {
        activeBotton = alpha == 1;
        if (gameSystem.State.Equals("waiting for orders") & ActiveBotton & !gameSystem.NowCharecter.disableAttack)
        {
            tutorialPlus();
            gameSystem.State = "Choose a enemy character";
            switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
}
