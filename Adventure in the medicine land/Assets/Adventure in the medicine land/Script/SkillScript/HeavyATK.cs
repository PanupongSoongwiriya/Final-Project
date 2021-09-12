using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyATK : Skill
{
    public HeavyATK(GameSystem gs)
    {
        gameSystem = gs;
        skillName = "Heavy ATK";
        desCripTion = "Select 1 enemy within the attack range to deal extra damage.";
        bonusEffect = 2;
    }
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

    }
    public override void changeState()
    {
        if (gameSystem.State.Equals("waiting for skill"))
        {
            gameSystem.NowCharecter.specialAttack += bonusEffect;
            gameSystem.State = "Use skills with enemies";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
    public override void cancelSkill()
    {
        gameSystem.NowCharecter.specialAttack -= bonusEffect;
    }
}
