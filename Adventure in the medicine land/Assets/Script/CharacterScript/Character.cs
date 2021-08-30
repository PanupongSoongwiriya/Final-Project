using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{

    public String faction;
    private String classs;
    public bool doneItYet;

    public int hp;

    public int x;
    public int y;

    public int attackPower;
    public int specialAttack;

    public int defensePower;
    public int specialDefense;

    private int walkingDistance;
    private int attackRange;

    public GameObject system;
    private GameSystem gameSystem;

    public GameObject controlPanel;

    public Character(String faction, String classs, int x, int y)
    {
        this.faction = faction;
        this.classs = classs;

        this.hp = 0;

        this.x = x;
        this.y = y;

        this.attackPower = 0;
        this.specialAttack = 0;

        this.defensePower = 0;
        this.specialDefense = 0;

        this.walkingDistance = 0;
        this.attackRange = 0;
    }

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
        if (gameSystem.State.Equals("Choose a medicine character") && faction.Equals("Medicine"))
        {
            gameSystem.NowCharecter = this;
            gameSystem.State = "waiting for orders";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, true, false);
        }
        else if (gameSystem.State.Equals("Choose a enemy character") && !gameSystem.NowCharecter.Faction.Equals(faction))
        {
            gameSystem.NowCharecter.doneIt();
            gameSystem.State = "Choose a medicine character";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false);
            checkHP();
        }
    }
    private void useSkill()
    {
    }
    private void defense()
    {
        specialDefense += 1;
    }

    public void checkHP()
    {
        int dmg = (gameSystem.NowCharecter.attackPower + gameSystem.NowCharecter.specialAttack) - (defensePower + specialDefense);
        hp -= Math.Max(0, dmg);
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

    private void memberUpdate()
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
}
