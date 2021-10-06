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
    public bool moving;

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
    public bot bot;

    void Start()
    {
        startSetUp();
    }

    void Update()
    {
        moveSmoothly();
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
        moving = false;
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
            status = true;
        }
        //Debuff
        else if (gameSystem.State.Equals("Debuff with enemies") && faction.Equals("Disease") && pedalFloor.InTerm)
        {
            status = true;
        }
        if (status)
        {
            String type = gameSystem.SkillType;
            int bonusEffect = gameSystem.SkillBonusEffect;

            if (type.Equals("ATK"))
            {
                showDMG(bonusEffect, "ATK");
                specialAttack += bonusEffect;
            }
            else if (type.Equals("DEF"))
            {
                showDMG(bonusEffect, "DEF");
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
                showDMG(bonusEffect, "MOVE");
                walkingDistance += bonusEffect;
            }
            else if (type.Equals("AR"))
            {
                showDMG(bonusEffect, "RANGE");
                attackRange += bonusEffect;
            }
            else if (type.Equals("ATK/DEF"))
            {
                int dmg = Math.Max(1, (int)(((gameSystem.NowCharecter.attackPower + gameSystem.NowCharecter.specialAttack) * checkAdvantage()) - (defensePower + specialDefense)));
                showDMG(-dmg, "attack");
                HP -= dmg;
                Invoke("showBuff", 1f);
                specialDefense += bonusEffect;
            }
            gameSystem.State = "Choose a medicine character";
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            if (!(type.Equals("ATK/DEF")))
            {
                gameSystem.SkillType = "";
                gameSystem.SkillBonusEffect = 0;
            }
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
            showDMG(-dmg, "attack");
            HP -= dmg;
        }
        //Bot Attack
        else if (gameSystem.State.Equals("round of bots") && !gameSystem.NowCharecter.Faction.Equals(faction) && pedalFloor.InTerm)
        {
            gameSystem.NowCharecter.doneIt();
            gameSystem.resetInTerm();
            int dmg = Math.Max(1, (int)(((gameSystem.NowCharecter.attackPower + gameSystem.NowCharecter.specialAttack) * checkAdvantage()) - (defensePower + specialDefense)));
            showDMG(-dmg, "attack");
            HP -= dmg;
        }
    }

    public void showDMG(int dmg, String typeDMG)
    {
        if (dmgText != null)
        {
            dmgText.GetComponent<DamageText>().num = dmg;
            dmgText.GetComponent<DamageText>().type = typeDMG;
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            Instantiate(dmgText, position, Quaternion.Euler(new Vector3(73.875f, 270, 0)));
        }
    }
    public void showBuff()
    {
        String type = gameSystem.SkillType;
        int bonusEffect = gameSystem.SkillBonusEffect;
        if (dmgText != null)
        {
            dmgText.GetComponent<DamageText>().num = bonusEffect;
            dmgText.GetComponent<DamageText>().type = type.Split("/"[0])[1];
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            Instantiate(dmgText, position, Quaternion.Euler(new Vector3(73.875f, 270, 0)));
            gameSystem.SkillType = "";
            gameSystem.SkillBonusEffect = 0;
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

    protected void moveSmoothly()
    {
        if (moving)
        {
            float smoothSpeed = 0.1f;
            bool equalsX = 0.1 > Math.Abs(transform.position.x - pedalFloor.transform.position.x);
            bool equalsZ = 0.1 > Math.Abs(transform.position.z - pedalFloor.transform.position.z);
            if (!(equalsX && equalsZ))
            {
                transform.position = new Vector3(transform.position.x, Math.Min(transform.position.y + smoothSpeed, 3.3f), transform.position.z);
            }
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
            //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            gameSystem.resetInTerm();
            if (transform.position.y == 3.3f)
            {
                Vector3 desiredPosition = pedalFloor.transform.position;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

                transform.position = new Vector3(smoothedPosition.x, transform.position.y, smoothedPosition.z);
            }
            if (equalsX && equalsZ)
            {
                if (transform.position.y != 2)
                {
                    transform.position = new Vector3(transform.position.x, Math.Max(transform.position.y - smoothSpeed, 2), transform.position.z);
                }
                else
                {
                    transform.position = new Vector3((int)Math.Round(transform.position.x), 2, (int)Math.Round(transform.position.z));
                    moving = false;
                    gameSystem.NowCharecter.doneIt();
                }
            }
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

    public Floor PedalFloor
    {
        get { return pedalFloor; }
        set { pedalFloor = value; moving = true; pedalFloor.characterOnIt = this; }
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
