using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    public String characterName;
    protected String faction;
    public String classCharacter;
    public bool doneItYet;

    public int hp;

    public int attackPower;
    public int specialAttack;

    public int defensePower;
    public int specialDefense;

    public int walkingDistance;
    public int attackRange;

    public GameSystem gameSystem;
    protected int beforeTurn = -1;
    public int indexSkill;


    public List<Skill> allSkill;



    void Start()
    {
        memberUpdate();
        doneItYet = true;
    }

    void Update()
    {
        resetSP();
    }

    void OnMouseDown()
    {
        showDetailDisease();
        prepare();
        attacked();
    }
    public void useSkill(int index)
    {
        indexSkill = index;
        allSkill[indexSkill].changeState();
    }
    protected void setPositionCamera()
    {
        if (!gameSystem.State.Equals("round of bots") || !gameSystem.State.Equals("walk") || !gameSystem.State.Equals("Choose a enemy character"))
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, GameObject.Find("Main Camera").transform.position.y, transform.position.z);
        }
    }

    protected void prepare()
    {
        if (gameSystem.State.Equals("Choose a medicine character") && faction.Equals("Medicine"))
        {
            setPositionCamera();
            gameSystem.NowCharecter = this;
            gameSystem.State = "waiting for orders";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, true, false, true, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
    protected void showDetailDisease()
    {
        if ((gameSystem.State.Equals("Choose a medicine character") && faction.Equals("Disease")) || (gameSystem.State.Equals("waiting for orders") && faction.Equals("Disease")))
        {
            setPositionCamera();
            gameSystem.NowCharecter = this;
            gameSystem.State = "Choose a medicine character";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, false, false, true, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }

    protected void attacked()
    {
        bool inEnimyTerm = false;
        if (gameSystem.NowCharecter != null)
        {
            double distance = (Math.Sqrt(Math.Pow((transform.position.x - gameSystem.NowCharecter.transform.position.x), 2) + Math.Pow((transform.position.z - gameSystem.NowCharecter.transform.position.z), 2))) / 6;
            inEnimyTerm = (gameSystem.NowCharecter.attackRange >= distance && (transform.position.x == gameSystem.NowCharecter.transform.position.x || transform.position.z == gameSystem.NowCharecter.transform.position.z));
        }if ((gameSystem.State.Equals("Choose a enemy character") || gameSystem.State.Equals("Use skills with enemies")) && !gameSystem.NowCharecter.Faction.Equals(faction) && inEnimyTerm)
        {
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            gameSystem.State = "Choose a medicine character";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            int dmg = (gameSystem.NowCharecter.attackPower + gameSystem.NowCharecter.specialAttack) - (defensePower + specialDefense);
            HP -= Math.Max(0, (int)(dmg * checkAdvantage()));
        }
    }

    protected virtual float checkAdvantage()
    {
        return 1;
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

    protected void resetSP()
    {
        if (beforeTurn != gameSystem.Turn)
        {
            beforeTurn = gameSystem.Turn;
            specialDefense = 0;
            specialAttack = 0;
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
    public GameSystem GS
    {
        get { return gameSystem; }
        set { gameSystem = value; }
    }
}
