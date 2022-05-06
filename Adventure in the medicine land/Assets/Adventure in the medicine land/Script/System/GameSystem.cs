using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSystem : MonoBehaviour
{
    protected int turn;
    public string whoTurn;
    public bool endGame = false;

    public string state;
    //("Choose a medicine character", "waiting for orders", "walk", "Choose a enemy character", "waiting for choose medicine", "Use medicine with ally", "round of bots")

    public Character nowCharecter;
    protected String skillType;
    protected int skillBonusEffect;
    public Status selectedMedicine;

    public GameObject controlPanel;

    public CameraFollow cf;
    public bool lockCamera = false;

    public GameObject dmgText;
    public YourTurn yourTurnText;
    public GameObject whoTurnPanel;
    public GameObject endGamePanel;
    public walkButton walkBoutton;
    public attackButton attackButton;
    public bagOptionsButton bagOptionsButton;

    public Animator anim;

    public List<GameObject> allFloor = new List<GameObject>();
    public List<GameObject> allFloorInTerm;
    public List<Character> allMedicineInTerm;
    public List<Character> medicineFaction = new List<Character>();
    public List<Character> diseaseFaction = new List<Character>();
    protected Dictionary<String, int> allClassID = new Dictionary<String, int>();

    public AutoGenerateStage AGS;

    [SerializeField]
    private AudioSource clickAudio;
    [SerializeField]
    private AudioSource Sound_Move;
    [SerializeField]
    private AudioSource Sound_Blow;
    [SerializeField]
    private AudioSource Sound_Crossbow;
    [SerializeField]
    private AudioSource Sound_Slash;
    [SerializeField]
    private AudioSource Sound_Damage;
    [SerializeField]
    private AudioSource Sound_Heal;
    
    public AudioSource BGM;

    public int saveManager;

    void Start()
    {
        Application.targetFrameRate = 120;
        WhoTurn = "Medicine";
        state = "Choose a medicine character";
        turn = 0;
        controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
        //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        cf = GameObject.Find("Game Camera").GetComponent<CameraFollow>();
        BGM.Play();
        endGamePanel.GetComponent<EndGame>().saveManager = saveManager;
        //BGM.Stop();
    }


    public void checkChangeTurn()
    {
        bool statusChangeTurn = true;
        if (WhoTurn == "Medicine")
        {
            foreach (Character medicine in medicineFaction)
            {
                if (medicine.ActionPoint > 0)
                {
                    statusChangeTurn = false;
                    State = "Choose a medicine character";
                    break;
                }
            }
        }
        else
        {
            foreach (Character disease in diseaseFaction)
            {
                if (disease.ActionPoint > 0)
                {
                    statusChangeTurn = false;
                    break;
                }
            }
        }
        if (statusChangeTurn)
        {
            //change whoTurn
            if (WhoTurn == "Medicine")
            {
                WhoTurn = "Disease";
                State = "round of bots";
                whoTurnPanel.GetComponent<whoTurn>().Changed();
                lockCamera = true;
            }
            else
            {
                WhoTurn = "Medicine";
                State = "Choose a medicine character";
            }
            //Debug.Log(WhoTurn + " Turn");

            //set doneItYet
            if (WhoTurn == "Medicine")
            {
                foreach (Character medicine in medicineFaction)
                {
                    medicine.ActionPoint = 2;
                }
                ++Turn;
            }
            else
            {
                foreach (Character disease in diseaseFaction)
                {
                    disease.ActionPoint = 2;
                }
                StartCoroutine(diseaseActive());
            }
        }
    }

    IEnumerator diseaseActive()
    {
        yield return new WaitForSeconds(0.25f);
        foreach (Character disease in diseaseFaction)
        {
            if (endGame)
            {
                break;
            }
            else
            {
                disease.GetComponent<BotDisease>().botActive();
                yield return new WaitForSeconds(2.25f);
            }
        }
    }

    IEnumerator changeTurn()
    {
        yield return new WaitForSeconds(1f);
        foreach (Character medicine in medicineFaction)
        {
            medicine.resetSP();
        }
        foreach (Character disease in diseaseFaction)
        {
            disease.resetSP();
        }
        foreach (GameObject floor in allFloor)
        {
            floor.GetComponent<Floor>().floorEffect();
        }
        if (!endGame)
        {
            cf.Target = transform;
            yourTurnText.stratMove();
            whoTurnPanel.GetComponent<whoTurn>().Changed();
            lockCamera = false;
        }
    }
    public void chackInTerm()
    {
        int checkTerm = -1;
        String doingWhat = "";

        if (State.Equals("waiting for orders") || State.Equals("waiting for choose medicine"))
        {
            resetInTerm();
        }
        else
        {
            if (State.Equals("walk"))
            {
                checkTerm = nowCharecter.walkingDistance;
                doingWhat = "walk";
            }
            else if (State.Equals("Choose a enemy character"))
            {
                checkTerm = nowCharecter.attackRange;
                doingWhat = "bad for the enemy";
            }
            else if (State.Equals("Use medicine with ally"))
            {
                checkTerm = nowCharecter.cureRange;
                doingWhat = "support";
            }
            if (nowCharecter != null && checkTerm != -1)
            {
                findDistance(checkTerm, doingWhat);
            }
        }
    }

    public void memberUpdate(Character chr)
    {
        bool without = true;
        chr.pressCharacter = clickAudio;
        chr.Sound_Move = Sound_Move;
        chr.Sound_Blow = Sound_Blow;
        chr.Sound_Crossbow = Sound_Crossbow;
        chr.Sound_Slash = Sound_Slash;
        chr.Sound_Damage = Sound_Damage;
        chr.Sound_Heal = Sound_Heal;
        if (chr.Faction.Equals("Medicine"))
        {
            medicineFaction.Add(chr);
        }
        else
        {
            diseaseFaction.Add(chr);
        }
        foreach (String key in allClassID.Keys)
        {
            if (chr.classCharacter.Equals(key))
            {
                without = false;
                break;
            }
        }
        if (without)
        {
            allClassID.Add(chr.classCharacter, 1);
        }
        chr.ID = allClassID[chr.classCharacter];
        allClassID[chr.classCharacter] += 1;
    }

    public void memberRemove(Character chr)
    {
        if (chr.Faction.Equals("Medicine"))
        {
            medicineFaction.Remove(chr);
        }
        else
        {
            diseaseFaction.Remove(chr);
        }
        if ((medicineFaction.Count == 0 || diseaseFaction.Count == 0) && !endGame)
        {
            endGame = true;
            Invoke("showEndGamePanel", 2f);
        }
    }

    public void showEndGamePanel()
    {
        endGamePanel.SetActive(true);
        endGamePanel.GetComponent<EndGame>().checkTheWin();
    }

    public virtual void resetGame()
    {
        anim.SetBool("FadeIn", true);
        anim.SetBool("FadeOut", false);
        lockCamera = false;
        cf.transform.position = transform.position;
        turn = 0;
        controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
        //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        foreach (Character medicine in medicineFaction)
        {
            medicine.selfDestruct();
        }
        foreach (Character disease in diseaseFaction)
        {
            disease.selfDestruct();
        }
        medicineFaction.Clear();
        diseaseFaction.Clear();
        allClassID.Clear();
        whoTurn = "Medicine";
        whoTurnPanel.GetComponent<whoTurn>().Changed();
        state = "Choose a medicine character";
        AGS.readStageImage();
        endGame = false;
    }

    public void botChackInTerm(int checkTerm, String doingWhat)
    {
        resetInTerm();
        allFloorInTerm.Clear();
        allMedicineInTerm.Clear();
        findDistance(checkTerm, doingWhat);
    }

    public void findDistance(int rang, String doingWhat)
    {
        List<int> charPosition = new List<int> { (int)NowCharecter.transform.position.x, (int)NowCharecter.transform.position.z };
        List<List<List<int>>> allPosition = new List<List<List<int>>>();

        int start_x = charPosition[0] - (6 * rang);
        int stop_x = charPosition[0] + (6 * (rang + 1));
        int step = 6;
        int start_z = charPosition[1] + (6 * rang);
        int stop_z = charPosition[1] - (6 * (rang + 1));

        //Find all boxes within a square.
        for (int z = start_z; z > stop_z; z -= step)
        {
            List<List<int>> lis = new List<List<int>>();
            for (int x = start_x; x < stop_x; x += step)
            {
                if (charPosition[0] == x && charPosition[1] == z)
                {
                    if (State.Equals("Use medicine with ally"))
                    {
                        lis.Add(new List<int> { x, z });
                    }
                }
                else
                {
                    lis.Add(new List<int> { x, z });
                }
            }
            allPosition.Add(lis);
        }
        List<List<int>> index = new List<List<int>>();

        //Find a square corner to remove the back to become a diamond.

        //Top Left
        for (int i = 0; i < rang; i++)
        {
            for (int j = 0; j < rang - i; j++)
            {
                index.Add(allPosition[i][j]);
            }
        }
        //Bottom Left
        for (int i = allPosition.Count - 1; i > allPosition.Count - rang - 1; i--)
        {
            for (int j = 0; j < rang - (allPosition.Count - 1 - i); j++)
            {
                index.Add(allPosition[i][j]);
            }
        }

        //Top Right
        for (int i = 0; i < rang; i++)
        {
            for (int j = allPosition.Count - 1; j > allPosition.Count - rang - 1 + i; j--)
            {
                index.Add(allPosition[i][j]);
            }
        }

        //Bottom Right
        for (int i = allPosition.Count - 1; i > allPosition.Count - rang - 1; i--)
        {
            for (int j = allPosition.Count - 1; j > allPosition.Count - rang - 1 + (allPosition.Count - 1 - i); j--)
            {
                index.Add(allPosition[i][j]);
            }
        }

        //Find the part that is not in the corner.
        List<List<int>> ans = new List<List<int>>();
        bool check;
        foreach (List<List<int>> i in allPosition)
        {
            foreach (List<int> j in i)
            {
                check = true;
                foreach (List<int> x in index)
                {
                    if (x.Equals(j))
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    ans.Add(j);
                }
            }
        }
        foreach (GameObject floor in allFloor)
        {
            int x = (int)floor.transform.position.x;
            int z = (int)floor.transform.position.z;
            foreach (List<int> position in ans)
            {
                if (position[0] == x && position[1] == z)
                {
                    if (NowCharecter.Faction.Equals("Disease"))
                    {
                        //Find out if there is a medicine character there or not.
                        foreach (Character medicine in medicineFaction)
                        {
                            int medicineX = (int)medicine.transform.position.x;
                            int medicineZ = (int)medicine.transform.position.z;
                            if (position[0] == medicineX && position[1] == medicineZ)
                            {
                                allMedicineInTerm.Add(medicine);
                                break;
                            }
                        }
                        if (floor.GetComponent<Floor>().characterOnIt == null && !floor.GetComponent<Floor>().typrFloor.Equals("poison"))
                        {
                            allFloorInTerm.Add(floor);
                        }
                    }
                    bool areYouAlly = true;
                    if (floor.GetComponent<Floor>().characterOnIt != null)
                    {
                        areYouAlly = floor.GetComponent<Floor>().characterOnIt.Faction.Equals(NowCharecter.Faction);
                    }
                    if (floor.GetComponent<Floor>().characterOnIt == null || (doingWhat.Equals("bad for the enemy") && !areYouAlly) || (doingWhat.Equals("support") && areYouAlly))
                    {
                        floor.GetComponent<Floor>().InTerm = true;
                    }
                    floor.GetComponent<Floor>().showInTerm(doingWhat);
                    break;
                }
            }
        }
    }
    public void resetInTerm()
    {
        foreach (GameObject floor in allFloor)
        {
            floor.GetComponent<Floor>().InTerm = false;
            floor.GetComponent<Floor>().showInTerm("");
        }
    }

    public string State
    {
        get { return state; }
        set
        {
            state = value;
            Debug.Log(state);
            chackInTerm();
        }
    }
    public Character NowCharecter
    {
        get { return nowCharecter; }
        set { nowCharecter = value; }
    }
    public String SkillType
    {
        get { return skillType; }
        set { skillType = value; }
    }
    public int SkillBonusEffect
    {
        get { return skillBonusEffect; }
        set { skillBonusEffect = value; }
    }
    public int Turn
    {
        get { return turn; }
        set { turn = value; StartCoroutine(changeTurn()); }
    }
    public string WhoTurn
    {
        get { return whoTurn; }
        set { whoTurn = value;}
    }
}
