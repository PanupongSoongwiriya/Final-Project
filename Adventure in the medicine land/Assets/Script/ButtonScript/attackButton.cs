using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackButton : controlPanelButton
{
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for orders"))
        {
            gameSystem.State = "Choose a enemy character";
            Debug.Log(gameSystem.State);
            //controlPanel.gameObject.SetActive(false);
        }
    }
}
