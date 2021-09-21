using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    public String characterName;
    protected String faction;
    public String classCharacter;
    public String genusPhase;
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
    public Floor pedalFloor;



    void Start()
    {
        gameSystem.memberUpdate(this);
        doneItYet = true;
    }

    void Update()
    {
        //resetSP();
    }

    void OnMouseDown()
    {
        showDetailDisease();
        prepare();
        attacked();
        checkBuffDebuff();
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
        if ((gameSystem.State.Equals("Choose a medicine character") || gameSystem.State.Equals("waiting for orders")) && faction.Equals("Medicine"))
        {
            setPositionCamera();
            gameSystem.NowCharecter = this;
            if (doneItYet)
            {
                gameSystem.State = "waiting for orders";
                gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, true, false, true, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            }
            else
            {
                gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(true, false, false, true, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            }
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
    protected void checkBuffDebuff()
    {
        bool status = false;
        //Buff
        if (gameSystem.State.Equals("Use skills with ally") && !gameSystem.NowCharecter.Equals(this) && faction.Equals("Medicine") && pedalFloor.InTerm)
        {
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            gameSystem.State = "Choose a medicine character";
            status = true;
        }
        //Debuff
        else if (gameSystem.State.Equals("Debuff with enemies") && faction.Equals("Disease") && pedalFloor.InTerm)
        {
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            gameSystem.State = "Choose a medicine character";
            status = true;
        }
        if (status)
        {
            String type = gameSystem.SkillType;
            int bonusEffect = gameSystem.SkillBonusEffect;

            if (type.Equals("ATK"))
            {
                specialAttack += bonusEffect;
            }else if (type.Equals("DEF"))
            {
                specialDefense += bonusEffect;
            }
        }
    }

    protected void attacked()
    {
        if ((gameSystem.State.Equals("Choose a enemy character") || gameSystem.State.Equals("Use skills with enemies")) && !gameSystem.NowCharecter.Faction.Equals(faction) && pedalFloor.InTerm)
        {
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            gameSystem.State = "Choose a medicine character";
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            int dmg = Math.Max(0, (int)((gameSystem.NowCharecter.attackPower + gameSystem.NowCharecter.specialAttack) - (defensePower + specialDefense) * checkAdvantage()));
            HP -= dmg;
        }
    }

    protected bool inTerm()
    {
        bool inEnimyTerm = false;
        if (gameSystem.NowCharecter != null)
        {
            double distance = (Math.Sqrt(Math.Pow((transform.position.x - gameSystem.NowCharecter.transform.position.x), 2) + Math.Pow((transform.position.z - gameSystem.NowCharecter.transform.position.z), 2))) / 6;
            inEnimyTerm = (gameSystem.NowCharecter.attackRange >= distance && (transform.position.x == gameSystem.NowCharecter.transform.position.x || transform.position.z == gameSystem.NowCharecter.transform.position.z));
        }
        return inEnimyTerm;
    }

    protected virtual float checkAdvantage()
    {
        return 1;
    }
    public void checkHP()
    {
        if (hp <= 0)
        {
            gameSystem.memberRemove(this);
            Destroy(this.gameObject);
        }

    }
    public void doneIt()
    {
        doneItYet = false;
        gameSystem.checkChangeTurn();
    }

    public void resetSP()
    {
        specialDefense = 0;
        specialAttack = 0;
        /*if (beforeTurn != gameSystem.Turn)
        {
            beforeTurn = gameSystem.Turn;
            specialDefense = 0;
            specialAttack = 0;
        }*/
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

    public Floor PedalFloor { 
        get { return pedalFloor; }
        set { pedalFloor = value; Debug.Log(name + ": " + value); }
    }
}
