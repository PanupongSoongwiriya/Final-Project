using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagOptionsButton : controlPanelButton
{
    public GameObject useButton;
    public override void changeState()
    {
        activeBotton = alpha == 1;
        if (gameSystem.State.Equals("waiting for orders") && ActiveBotton)
        {
            tutorialPlus();
            gameSystem.State = "waiting for choose medicine";
            useButton.SetActive(true);
            bagDetailPanel.GetComponent<BagDetailPanel>().gameSystem = gameSystem;
            switchPanel(true, false, true, false, true);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, bagDetailPanel
        }
    }
}
