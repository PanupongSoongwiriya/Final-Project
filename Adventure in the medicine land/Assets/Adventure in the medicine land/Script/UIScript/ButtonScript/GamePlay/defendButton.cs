using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defendButton : controlPanelButton
{
    public override void changeState()
    {
        activeBotton = c == 1;
        if (gameSystem.State.Equals("waiting for orders") && ActiveBotton)
        {
            ConfirmAudio.Play();
            tutorialPlus();
            gameSystem.NowCharecter.SP_Def += 10;
            /*if (gameSystem.NowCharecter.ClassType.Equals("Tank"))
            {
                gameSystem.NowCharecter.SP_Def += 1;
                gameSystem.NowCharecter.taunts = true;
            }*/
            gameSystem.State = "Choose a medicine character";
            switchPanel(false, true, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            gameSystem.NowCharecter.doneIt(2);
        }
    }
}
