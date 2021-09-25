using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSystem : MonoBehaviour
{
    private int turn;
    public string whoTurn;

    private string state;
    //("Choose a medicine character", "waiting for orders", "walk", "Choose a enemy character", "waiting for skill", "Use skills with enemies", "Use skills with ally", "Debuff with enemies", "round of bots")

    private Character nowCharecter;
    private String skillType;
    private int skillBonusEffect;
    public GameObject controlPanel;
    public CameraFollow cf;
    public GameObject dmgText;

    public List<GameObject> allFloor = new List<GameObject>();
    public List<GameObject> allFloorInTerm;
    public List<Character> medicineFaction = new List<Character>();
    public List<Character> diseaseFaction = new List<Character>();
    private Dictionary<String, int> allClassID = new Dictionary<string, int>();

    void Start()
    {
        whoTurn = "Medicine";
        state = "Choose a medicine character";
        turn = 0;
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
            disease.GetComponent<bot>().botWalk();
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
    }
    public void chackInTerm()
    {
        int checkTerm = -1;

        if (State == "waiting for orders" || State == "waiting for skill")
        {
            resetInTerm();
        }
        else
        {
            if (State == "walk")
            {
                checkTerm = nowCharecter.walkingDistance;
            }
            else if (State == "Choose a enemy character" || State == "Use skills with enemies" || State == "Debuff with enemies" || State == "Use skills with ally")
            {
                checkTerm = nowCharecter.attackRange;
            }
            if(nowCharecter != null)
            {
                findDistance(checkTerm);
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
    }

    public void botChackInTerm()
    {
        allFloorInTerm.Clear();
        int checkTerm = nowCharecter.walkingDistance;
        findDistance(checkTerm);
    }

    public void findDistance(int rang)
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
                        foreach(Character medicine in medicineFaction)
                        {
                            int medicineX = (int)medicine.transform.position.x;
                            int medicineZ = (int)medicine.transform.position.z;
                            if (position[0] == medicineX && position[1] == medicineZ)
                            {
                                add = false;
                                break;
                            }
                        }
                        if (add)
                        {
                            allFloorInTerm.Add(floor);
                        }
                    }
                    else
                    {
                        floor.GetComponent<Floor>().InTerm = true;
                    }
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
