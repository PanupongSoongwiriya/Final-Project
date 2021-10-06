using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    private int turn;
    public string whoTurn;
    public bool endGame = false;

    public string state;
    //("Choose a medicine character", "waiting for orders", "walk", "Choose a enemy character", "waiting for skill", "Use skills with enemies", "Use skills with ally", "Debuff with enemies", "round of bots")

    public Character nowCharecter;
    private String skillType;
    private int skillBonusEffect;

    public GameObject controlPanel;

    public CameraFollow cf;
    public bool lockCamera = false;

    public GameObject dmgText;
    public GameObject yourTurnText;
    public GameObject whoTurnPanel;
    public GameObject endGamePanel;

    public Animator anim;

    public List<GameObject> allFloor = new List<GameObject>();
    public List<GameObject> allFloorInTerm;
    public List<Character> allMedicineInTerm;
    public List<Character> medicineFaction = new List<Character>();
    public List<Character> diseaseFaction = new List<Character>();
    private Dictionary<String, int> allClassID = new Dictionary<string, int>();

    public AutoGenerateStage AGS;

    void Start()
    {
        whoTurn = "Medicine";
        state = "Choose a medicine character";
        turn = 0;
        controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
        //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        cf = GameObject.Find("Game Camera").GetComponent<CameraFollow>();
    }

    public void checkChangeTurn()
    {
        bool statusChangeTurn = true;
        if (whoTurn == "Medicine")
        {
            foreach (Character medicine in medicineFaction)
            {
                if (medicine.doneItYet)
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
                if (disease.doneItYet)
                {
                    statusChangeTurn = false;
                    break;
                }
            }
        }
        if (statusChangeTurn)
        {
            //change whoTurn
            if (whoTurn == "Medicine")
            {
                whoTurn = "Disease";
                State = "round of bots";
                whoTurnPanel.GetComponent<whoTurn>().Changed();
                lockCamera = true;
            }
            else
            {
                whoTurn = "Medicine";
                State = "Choose a medicine character";
            }
            Debug.Log(whoTurn + " Turn");

            //set doneItYet
            if (whoTurn == "Medicine")
            {
                foreach (Character medicine in medicineFaction)
                {
                    medicine.doneItYet = true;
                }
                ++Turn;
            }
            else
            {
                foreach (Character disease in diseaseFaction)
                {
                    disease.doneItYet = true;
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
            disease.GetComponent<bot>().botActive();
            yield return new WaitForSeconds(1.25f);
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
            Instantiate(yourTurnText, new Vector3(0, 25, 33), Quaternion.Euler(73.875f, 270, 0));
            whoTurnPanel.GetComponent<whoTurn>().Changed();
            lockCamera = false;
        }

    }
    public void chackInTerm()
    {
        int checkTerm = -1;
        String doingWhat = "";

        if (State.Equals("waiting for orders") || State.Equals("waiting for skill"))
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
            else if (State.Equals("Choose a enemy character") || State.Equals("Use skills with enemies") || State.Equals("Debuff with enemies"))
            {
                checkTerm = nowCharecter.attackRange;
                doingWhat = "bad for the enemy";
            }
            else if (State.Equals("Use skills with ally"))
            {
                checkTerm = nowCharecter.attackRange;
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

    public void resetGame()
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
        foreach(GameObject floor in allFloor)
        {
            int x = (int)floor.transform.position.x;
            int z = (int)floor.transform.position.z;
            foreach(List<int> position in ans)
            {
                if (position[0] == x && position[1] == z)
                {
                    if (NowCharecter.Faction.Equals("Disease"))
                    {
                        bool add = true;
                        //Find out if there is a medicine character there or not.
                        foreach (Character medicine in medicineFaction)
                        {
                            int medicineX = (int)medicine.transform.position.x;
                            int medicineZ = (int)medicine.transform.position.z;
                            if (position[0] == medicineX && position[1] == medicineZ)
                            {
                                add = false;
                                allMedicineInTerm.Add(medicine);
                                break;
                            }
                        }
                        if (add)
                        {
                            //Find out if there is a disease character there or not.
                            foreach (Character disease in diseaseFaction)
                            {
                                int diseaseX = (int)disease.transform.position.x;
                                int diseaseZ = (int)disease.transform.position.z;
                                if (position[0] == diseaseX && position[1] == diseaseZ)
                                {
                                    add = false;
                                    break;
                                }
                            }
                        }
                        if (add)
                        {
                            allFloorInTerm.Add(floor);
                        }
                    }
                    floor.GetComponent<Floor>().InTerm = true;
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
}
