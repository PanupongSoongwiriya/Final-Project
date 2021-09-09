using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    public String characterName;
    public String faction;
    public String classCharacter;
    public bool doneItYet;

    public int hp;

    public int x;
    public int y;

    public int attackPower;
    public int specialAttack;

    public int defensePower;
    public int specialDefense;

    public int walkingDistance;
    public int attackRange;

    public GameObject system;
    protected GameSystem gameSystem;

   
    protected List<Skill> allSkill;

    

    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
        memberUpdate();
        doneItYet = true;
    }

    void Update()
    {

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
            int dmg = (gameSystem.NowCharecter.attackPower + gameSystem.NowCharecter.specialAttack) - (defensePower + specialDefense);
            HP -= Math.Max(0, dmg);
        }
    }
    protected void useSkill()
    {
    }
    private void defense()
    {
        specialDefense += 1;
    }

    public void checkHP()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    public void doneIt()
    {
        doneItYet = false;
        gameSystem.checkChangeTurn();
    }

    protected void memberUpdate()
    {
        if (faction.Equals("Medicine"))
        {
            gameSystem.medicineFaction.Add(this);
        }
        else
        {
            gameSystem.diseaseFaction.Add(this);
        }
    }
    public String Faction
    {
        get { return faction; }
        set { faction = value; }
    }
    public int HP
    {
        get { return hp; }
        set { hp = value; checkHP(); }
    }
}
