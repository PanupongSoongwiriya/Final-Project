using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyATK : Skill
{
    public HeavyATK()
    {
    }
    void Start()
    {
        skillName = "Heavy ATK";
        desCripTion = "Select 1 enemy within the attack range to deal extra damage.";
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.State = "Use skills with enemies";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
}
