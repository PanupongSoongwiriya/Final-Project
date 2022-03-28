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
    [SerializeField]
    protected String classType;
    [SerializeField]
    protected int actionPoint;
    public bool moving;

    public bool spinning;
    public GameObject targetSpin;
    public int spinDirection;

    [SerializeField]
    protected float newRotateY;

    [SerializeField]
    protected GameObject chrNearest;

    public Status characterStatus;

    public int hp;
    public int maxHP;
    public int THE_REAL_MAX_HP;

    public int attackPower;
    [SerializeField]
    protected int specialAttack;

    public int defensePower;
    [SerializeField]
    protected int specialDefense;

    public int walkingDistance;
    public int attackRange;
    public int cureRange;

    public GameSystem gameSystem;
    public int indexSkill;
    public bool taunts;
    public bool disableMove;
    public bool disableAttack;

    public List<Status> bag;
    public GameObject status;
    public Floor pedalFloor;
    public GameObject dmgText;
    public BotDisease botDisease;

    public AudioSource pressCharacter;

    [SerializeField]
    protected List<Renderer> allRenderer = new List<Renderer>();

    [SerializeField]
    protected Animator animator;

    public Sprite image;


    void Start()
    {
        startSetUp();
    }

    void Update()
    {
        moveSmoothly();
        spinToTarget();
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected void allAction()
    {
        if (!gameSystem.endGame)
        {
            showDetailDisease();
            prepare();
            canCureDisease();
            attacked();
            tutorialPlus();
        }
    }

    protected void startSetUp()
    {
        moving = false;
        maxHP = hp;
        THE_REAL_MAX_HP = hp;
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }
        gameSystem.memberUpdate(this);
        dmgText = gameSystem.dmgText;
        ActionPoint = 2;
        resetRange();
        if (Faction.Equals("Disease"))
        {
            botDisease = gameObject.AddComponent<BotDisease>();
            botDisease.chr = this;
            botDisease.gameSystem = gameSystem;
        }

        name = classCharacter + " " + id;
        status = GameObject.Find("StatusList");
        bag = new List<Status>();
        findAllMaterial(transform);
        targetSpin = null;
        setColorCharacter(new Color(1, 1, 1, 1));
        animator = GetComponent<Animator>();
        ClassType = "";
    }

    public void setDegree()
    {
        if (faction.Equals("Medicine"))
        {
            foreach (Character disease in gameSystem.diseaseFaction)
            {
                if (chrNearest != null)
                {
                    Vector3 position1 = transform.position;
                    Vector3 position2 = chrNearest.transform.position;
                    double Old = Math.Sqrt(Math.Pow((position1.x - position2.x), 2) + Math.Pow((position1.z - position2.z), 2));
                    position2 = disease.transform.position;
                    double New = Math.Sqrt(Math.Pow((position1.x - position2.x), 2) + Math.Pow((position1.z - position2.z), 2));
                    if (New < Old)
                    {
                        chrNearest = disease.gameObject;
                    }
                }
                else
                {
                    chrNearest = disease.gameObject;
                }
            }
        }
        else
        {
            foreach (Character medicine in gameSystem.medicineFaction)
            {
                if (chrNearest != null)
                {
                    Vector3 position1 = transform.position;
                    Vector3 position2 = chrNearest.transform.position;
                    double Old = Math.Sqrt(Math.Pow((position1.x - position2.x), 2) + Math.Pow((position1.z - position2.z), 2));
                    position2 = medicine.transform.position;
                    double New = Math.Sqrt(Math.Pow((position1.x - position2.x), 2) + Math.Pow((position1.z - position2.z), 2));
                    if (New < Old)
                    {
                        chrNearest = medicine.gameObject;
                    }
                }
                else
                {
                    chrNearest = medicine.gameObject;
                }
            }
        }
        Vector3 posSelf = transform.position;
        Vector3 posTarget = chrNearest.transform.position;

        float adj = posTarget.z - posSelf.z;
        float opp = posTarget.x - posSelf.x;

        float inverse = 0;
        if (posSelf.z > posTarget.z)
        {
            inverse = 180;
        }

        float y = ((Mathf.Atan(opp / adj) * Mathf.Rad2Deg) + inverse);
        if (y > 180)
        {
            y -= 360;
        }
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, y, transform.eulerAngles.z);
    }
    protected void setPositionCamera()
    {
        if (!gameSystem.State.Equals("round of bots") || !gameSystem.State.Equals("walk") || !gameSystem.State.Equals("Choose a enemy character"))
        {
            gameSystem.cf.Target = transform;
            pressCharacter.Play();
        }
    }

    protected void prepare()
    {
        if ((gameSystem.State.Equals("Choose a medicine character") || gameSystem.State.Equals("waiting for orders")) && faction.Equals("Medicine"))
        {
            setPositionCamera();
            gameSystem.NowCharecter = this;
            gameSystem.walkBoutton.ActiveBotton = actionPoint == 2 && !disableMove;
            gameSystem.attackButton.ActiveBotton = !disableAttack;
            gameSystem.bagOptionsButton.ActiveBotton = bag.Count > 0;
            if (actionPoint > 0)
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

    protected void canCureDisease()
    {
        if (gameSystem.State.Equals("Use medicine with ally") && faction.Equals("Medicine") && pedalFloor.InTerm)
        {
            if (gameSystem.selectedMedicine.IsStatusEffective(characterStatus))
            {
                CharacterStatus.retrospectiveStatus(this);
                CharacterStatus = gameSystem.selectedMedicine;
            }
            else if(gameSystem.selectedMedicine.statusName.Equals("ผ้าพันแผล"))
            {
                /*If not a Class Hero person or a doctor, The bandage can only be used once.*/
                if (!gameSystem.NowCharecter.classCharacter.Equals("ผู้กล้า") && !gameSystem.NowCharecter.classCharacter.Equals("หมอ"))
                {
                    for (int i = 0; i < gameSystem.NowCharecter.bag.Count; i++)
                    {
                        if (gameSystem.NowCharecter.bag[i].Type.Equals("Bandage"))
                        {
                            gameSystem.NowCharecter.bag.RemoveAt(i);
                            break;
                        }
                    }
                }
                gameSystem.selectedMedicine.statusEffect(this);
            }
            gameSystem.selectedMedicine = null;
            gameSystem.State = "Choose a medicine character";
            gameSystem.NowCharecter.doneIt(2);
            gameSystem.resetInTerm();
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
            //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }

    public void attacked()
    {
        //Player Attack
        if (gameSystem.State.Equals("Choose a enemy character") && !gameSystem.NowCharecter.Faction.Equals(faction) && pedalFloor.InTerm)
        {
            gameSystem.State = "Choose a medicine character";
            gameSystem.NowCharecter.doneIt(2);
            gameSystem.NowCharecter.TargetSpin = gameObject;
            gameSystem.resetInTerm();
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
            //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            int dmg = calculateDMG(gameSystem.NowCharecter, this);
            showDMG(-dmg, "attack");
            HP(-dmg);
            gameSystem.NowCharecter.SetAnimBool("Attack");
        }
        //Bot Attack
        else if (gameSystem.State.Equals("round of bots") && !gameSystem.NowCharecter.Faction.Equals(faction) && pedalFloor.InTerm)
        {
            gameSystem.NowCharecter.doneIt(2);
            gameSystem.NowCharecter.TargetSpin = gameObject;
            gameSystem.resetInTerm();
            int dmg = calculateDMG(gameSystem.NowCharecter, this); 
            showDMG(-dmg, "attack");
            HP(-dmg);
            gameSystem.NowCharecter.SetAnimBool("Attack");
        }
    }

    public void showDMG(int dmg, String typeDMG)
    {
        if (dmg < 0)
        {
        }
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
    public int calculateDMG(Character attacker, Character victim)
    {
        //return Math.Max(1, (int)(((attacker.attackPower + attacker.specialAttack) * victim.checkAdvantage(attacker)) - (victim.defensePower + victim.specialDefense)));
        return Math.Max(1, (int)((attacker.attackPower + attacker.specialAttack) - (victim.defensePower + victim.specialDefense)));
    }

    IEnumerator checkHP()
    {
        if (hp <= 0)
        {
            SetAnimBool("Die");
            gameSystem.memberRemove(this);
            yield return new WaitForSeconds(3);
            selfDestruct();
        }
        else
        {
            SetAnimBool("GetHit");
        }
    }

    public void selfDestruct()
    {
        if (Faction.Equals("Disease"))
        {
            botDisease.deleteData();
        }
        Destroy(this.gameObject);
    }
    public void doneIt(int apUse)
    {
        ActionPoint = Math.Max(ActionPoint - apUse, 0);
        gameSystem.checkChangeTurn();
        if (Faction.Equals("Disease"))
        {
            botDisease.deleteData();
        }
    }

    public void resetSP()
    {
        specialDefense = 0;
        specialAttack = 0;
        taunts = false;
        resetRange();
        /*if (!gameSystem.State.Equals("Use medicine with ally") & faction.Equals("Medicine") & characterStatus != null)
        {
            characterStatus.statusEffect(this);
        }*/
    }
    protected virtual void resetRange()
    {
        walkingDistance = 0;
        attackRange = 0;
    }
    protected void spinToTarget()
    {
        if (spinning)
        {
            float speedSpin = 15*spinDirection;
            float targetRotate = newRotateY;
            if (targetRotate < 0)
            {
                targetRotate += 360;
            }
            if (targetRotate == 0 & transform.eulerAngles.y > 180)
            {
                targetRotate = 360;
            }
            float slowDownSpin = 1;
            if (Math.Abs(speedSpin * 2) > Math.Abs(transform.eulerAngles.y - targetRotate))
            {
                slowDownSpin = 0.1f;
            }
            if (Math.Abs(speedSpin*1.5f) > Math.Abs(transform.eulerAngles.y - targetRotate))
            {
                spinning = false;
            }

            float newY = transform.eulerAngles.y + (speedSpin* slowDownSpin);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, newY, transform.eulerAngles.z);

        }
    }
    protected void moveSmoothly()
    {
        if (moving)
        {
            animator.SetBool("Walk", true);
            float topPos = 4;
            float smoothSpeed = 0.6f;
            bool equalsX = 0.1 > Math.Abs(transform.position.x - pedalFloor.transform.position.x);
            bool equalsZ = 0.1 > Math.Abs(transform.position.z - pedalFloor.transform.position.z);
            if (!(equalsX && equalsZ))
            {
                transform.position = new Vector3(transform.position.x, Math.Min(transform.position.y + smoothSpeed, topPos), transform.position.z);
            }
            gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
            //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
            gameSystem.resetInTerm();
            if (transform.position.y == topPos)
            {
                Vector3 desiredPosition = pedalFloor.transform.position;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

                transform.position = new Vector3(smoothedPosition.x, transform.position.y, smoothedPosition.z);
            }
            if (equalsX && equalsZ)
            {
                float y = 0;
                if (transform.position.y > y)
                {
                    transform.position = new Vector3(transform.position.x, Math.Max(transform.position.y - smoothSpeed, y), transform.position.z);
                }
                else
                {
                    transform.position = new Vector3((int)Math.Round(transform.position.x), y, (int)Math.Round(transform.position.z));
                    moving = false;
                    animator.SetBool("Walk", false);
                    if (gameSystem.NowCharecter != null)
                    {
                        gameSystem.NowCharecter.doneIt(1);
                        if (gameSystem.NowCharecter.Faction.Equals("Disease"))
                        {
                            gameSystem.NowCharecter.gameObject.GetComponent<BotDisease>().afterWolk();
                        }
                    }
                }
            }
        }
    }
    protected void tutorialPlus()
    {
        if (gameSystem.name.Equals("TutorialSystem"))
        {
            if (gameSystem.GetComponent<TutorialSystem>().TutorialStep != 7)
            {
                gameSystem.GetComponent<TutorialSystem>().TutorialStep++;
            }
        }
    }
    public String Faction
    {
        get { return faction; }
        set { faction = value; }
    }
    public String ClassType
    {
        get { return classType; }
        set { classType = value; }
    }
    public void HP(int value)
    {
        hp = Math.Min(MAXHP, hp + value);
        if (value < 0)
        {
            StartCoroutine(checkHP());
        }
    }
    public GameSystem GS
    {
        get { return gameSystem; }
        set { gameSystem = value; }
    }

    public Floor PedalFloor
    {
        get { return pedalFloor; }
        set { 
            pedalFloor = value; 
            moving = true;
            pedalFloor.characterOnIt = this;
            
            if (!(value.transform.position.x == transform.position.x && value.transform.position.z == transform.position.z))
            {
                TargetSpin = pedalFloor.gameObject;
            }
        }
    }

    public GameObject TargetSpin
    {
        get { return targetSpin; }
        set
        {
            targetSpin = value;
            Vector3 posSelf = transform.position;
            Vector3 posTarget = value.transform.position;

            float adj = posTarget.z - posSelf.z;
            float opp = posTarget.x - posSelf.x;

            float inverse = 0;
            if (posSelf.z > posTarget.z)
            {
                inverse = 180;
            }

            newRotateY = ((Mathf.Atan(opp / adj) * Mathf.Rad2Deg) + inverse);
            if (newRotateY > 180)
            {
                newRotateY -= 360;
            }
            spinDirection = 1;
            float targetRotate = newRotateY;
            if (targetRotate < 0)
            {
                targetRotate += 360;
            }
            if (targetRotate == 0)
            {
                targetRotate = 360;
            }
            if ((Math.Abs(targetRotate-360)+ transform.eulerAngles.y)%360 < (Math.Abs(transform.eulerAngles.y - 360) + targetRotate) % 360)
            {
                spinDirection = -1;
            }
            spinning = true;
        }
    }
    
    protected void findAllMaterial(Transform t)
    {
        int childCount = t.childCount;
        if (Faction.Equals("Medicine"))
        {
            for (int c = 0; c < childCount; c++)
            {
                foreach (Renderer r in t.GetChild(c).GetComponents(typeof(Renderer)))
                {
                    allRenderer.Add(r);
                }
                if (t.GetChild(c).transform.childCount != 0 & t.GetChild(c).GetComponents(typeof(Renderer)).Length == 0)
                {
                    findAllMaterial(t.GetChild(c).transform);
                }
            }
        }
    }

    protected void setColorCharacter(Color c)
    {
        if (Faction.Equals("Medicine"))
        {
            foreach (Renderer r in allRenderer)
            {
                r.material.SetColor("_EmissionColor", c);
            }
        }
    }

    public void SetAnimBool(string var)
    {
        if (animator != null)
        {
            animator.SetBool(var, true);
            if (var.Equals("GetHit") || var.Equals("Attack"))
            {
                StartCoroutine(SwitchSetAnimBool(var));
            }
        }
    }

    IEnumerator SwitchSetAnimBool(string var)
    {
        yield return new WaitForSeconds(0.25f);
        animator.SetBool(var, false);
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
    public int SP_Atk
    {
        get { return specialAttack; }
        set { specialAttack = value; }
    }
    public int SP_Def
    {
        get { return specialDefense; }
        set { specialDefense = value; }
    }
    public bool DisableMove
    {
        get { return disableMove; }
        set { disableMove = value; }
    }
    public bool DisableAttack
    {
        get { return disableAttack; }
        set { disableAttack = value; }
    }
    public int ActionPoint
    {
        get { return actionPoint; }
        set
        {
            actionPoint = value;
            float newC = 1;
            if (value == 0)
            {
                newC = 0.4f;
            }
            if (CharacterStatus != null)
            {
                setColorCharacter(new Color(CharacterStatus.color.r * newC, CharacterStatus.color.g * newC, CharacterStatus.color.b * newC, 1));
            }
            else
            {
                setColorCharacter(new Color(1* newC, 1* newC, 1* newC, 1));
            }
        }
    }

    public Status CharacterStatus
    {
        get { return characterStatus; }
        set 
        {
            characterStatus = value;
            if (value != null)
            {
                animator.SetBool("Infect", value.statusType.Equals("disease"));
                float newC = 1;
                if (ActionPoint == 0)
                {
                    newC = 0.4f;
                }
                setColorCharacter(new Color(value.color.r * newC, value.color.g * newC, value.color.b * newC, 1));
            }
        }
    }
}
