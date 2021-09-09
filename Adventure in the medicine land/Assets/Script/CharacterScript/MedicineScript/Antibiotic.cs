using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Antibiotic : Character
{
    void Start()
    {
        characterName = "Hero";
        faction = "Medicine";
        classCharacter = "Antibiotic";

        HP = 10;

        attackPower = 2;
        defensePower = 1;

        walkingDistance = 3;
        attackRange = 1;


        gameSystem = system.GetComponent<GameSystem>();
        memberUpdate();
        doneItYet = true;

        allSkill.Add(new HeavyATK());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float checkAdvantage()
    {
        if (gameSystem.NowCharecter.classCharacter.Equals("Infect"))
        {
            return 0.5f;
        }
        return 1;
        
    }

    void OnMouseDown()
    {
        bool inEnimyTerm = false;
        double distance = -1;
        if (gameSystem.NowCharecter != null)
        {
            distance = (Math.Sqrt(Math.Pow((transform.position.x - gameSystem.NowCharecter.transform.position.x), 2) + Math.Pow((transform.position.z - gameSystem.NowCharecter.transform.position.z), 2))) / 6;
            inEnimyTerm = (gameSystem.NowCharecter.attackRange >= distance && (transform.position.x == gameSystem.NowCharecter.transform.position.x || transform.position.z == gameSystem.NowCharecter.transform.position.z));
        }
        if (gameSystem.State.Equals("Choose a medicine character") && faction.Equals("Medicine"))
        {
            gameSystem.NowCharecter = this;
            gameSystem.State = "waiting for orders";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, true, false, true, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
        else if (gameSystem.State.Equals("Choose a enemy character") && !gameSystem.NowCharecter.Faction.Equals(faction) && inEnimyTerm)
        {
            gameSystem.NowCharecter.doneIt();
            gameSystem.State = "Choose a medicine character";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            checkAdvantage();
            int dmg = (gameSystem.NowCharecter.attackPower + gameSystem.NowCharecter.specialAttack) - (defensePower + specialDefense);
            HP -= Math.Max(0, (int)(dmg*checkAdvantage()));
        }
    }
}
