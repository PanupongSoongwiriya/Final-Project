using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    public String characterName;
    public int id;
    public String faction;
    public String classCharacter;
    public String genusPhase;
    public bool doneItYet;

    public int hp;
    public int maxHP;

    public int attackPower;
    public int specialAttack;

    public int defensePower;
    public int specialDefense;

    public int walkingDistance;
    public int attackRange;

    public GameSystem gameSystem;
    public int indexSkill;


    public List<Skill> allSkill;
    public GameObject skill;
    public Floor pedalFloor;
    public GameObject dmgText;
    protected bot bot;

    void Start()
    {
        startSetUp();
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected void allAction()
    {
        if (!gameSystem.endGame){
            showDetailDisease();
            prepare();
            attacked();
            checkBuffDebuff();
        }
    }

    protected void startSetUp()
    {
        maxHP = hp;
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        gameSystem.memberUpdate(this);
        dmgText = gameSystem.dmgText;
        doneItYet = true;
        resetRange();
        if (Faction.Equals("Disease"))
        {
            bot = gameObject.AddComponent<bot>();
            bot.chr = this;
            bot.gameSystem = gameSystem;
        }

        name = classCharacter + " " + id;
        skill = GameObject.Find("SkillList");
        allSkill = new List<Skill>();
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
            gameSystem.cf.Target = transform;
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
            gameSystem.State = "Choose a medicine character";
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            status = true;
        }
        //Debuff
        else if (gameSystem.State.Equals("Debuff with enemies") && faction.Equals("Disease") && pedalFloor.InTerm)
        {
            gameSystem.State = "Choose a medicine character";
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            status = true;
        }
        if (status)
        {
            String type = gameSystem.SkillType;
            int bonusEffect = gameSystem.SkillBonusEffect;

            if (type.Equals("ATK"))
            {
                specialAttack += bonusEffect;
            }
            else if (type.Equals("DEF"))
            {
                specialDefense += bonusEffect;
            }
            else if (type.Equals("HP"))
            {
                if (bonusEffect > 0)
                {
                    showDMG(Math.Min(MAXHP - HP, bonusEffect), "heal");
                }
                HP = Math.Min(HP + bonusEffect, MAXHP);
            }
            else if (type.Equals("WD"))
            {
                walkingDistance += bonusEffect;
            }
            else if (type.Equals("AR"))
            {
                attackRange += bonusEffect;
            }
            gameSystem.SkillType = "";
            gameSystem.SkillBonusEffect = 0;
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
            //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }

    public void attacked()
    {
        //Player Attack
        if ((gameSystem.State.Equals("Choose a enemy character") || gameSystem.State.Equals("Use skills with enemies")) && !gameSystem.NowCharecter.Faction.Equals(faction) && pedalFloor.InTerm)
        {
            gameSystem.State = "Choose a medicine character";
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
            //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            int dmg = Math.Max(1, (int)(((gameSystem.NowCharecter.attackPower + gameSystem.NowCharecter.specialAttack) * checkAdvantage()) - (defensePower + specialDefense)));
            showDMG(-dmg, "Character");
            HP -= dmg;
        }
        //Bot Attack
        else if (gameSystem.State.Equals("round of bots") && !gameSystem.NowCharecter.Faction.Equals(faction) && pedalFloor.InTerm)
        {
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            int dmg = Math.Max(1, (int)(((gameSystem.NowCharecter.attackPower + gameSystem.NowCharecter.specialAttack) * checkAdvantage()) - (defensePower + specialDefense)));
            showDMG(-dmg, "Character");
            HP -= dmg;
        }
    }

    public void showDMG(int dmg, String typeDMG)
    {
        if (dmgText != null)
        {
            dmgText.GetComponent<DamageText>().dmg = dmg;
            dmgText.GetComponent<DamageText>().typeDMG = typeDMG;
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            Instantiate(dmgText, position, Quaternion.Euler(new Vector3(90, 270, 0)));
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
            gameSystem.memberRemove(this);
            selfDestruct();
        }

    }

    public void selfDestruct()
    {
        Destroy(this.gameObject);
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
        resetRange();
    }
    protected virtual void resetRange()
    {
        walkingDistance = 0;
        attackRange = 0;
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

    public Floor PedalFloor
    {
        get { return pedalFloor; }
        set { pedalFloor = value; }
    }
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    public int MAXHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }
}
