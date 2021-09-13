using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSystem : MonoBehaviour
{
    private int turn;
    public string whoTurn;
    private string state;//("Choose a medicine character", "waiting for orders", "walk", "Choose a enemy character", "waiting for skill", "Use skills with enemies", "Use skills with ally", "round of bots")
    private Character nowCharecter;
    public GameObject controlPanel;

    public List<GameObject> allFloor;
    public List<GameObject> allFloorInTerm;
    public List<Character> medicineFaction;
    public List<Character> diseaseFaction;
    void Start()
    {
        turn = 0;
        whoTurn = "Medicine";
        State = "Choose a medicine character";
        allFloor = new List<GameObject>();
        medicineFaction = new List<Character>();
        diseaseFaction = new List<Character>();

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
                botChackInTerm();//test
            }
            else
            {
                whoTurn = "Medicine";
                State = "Choose a medicine character";
                changeTurn();
            }
            Debug.Log(whoTurn + " Turn");

            //set doneItYet
            if (whoTurn == "Medicine")
            {
                foreach (Character medicine in medicineFaction)
                {
                    medicine.doneItYet = true;
                }
            }
            else
            {
                foreach (Character disease in diseaseFaction)
                {
                    disease.doneItYet = true;
                }
            }
        }
    }
    public void changeTurn()
    {
        turn++;
        foreach (GameObject floor in allFloor)
        {
            floor.GetComponent<Floor>().changeTurn = true;
        }
    }
    public void chackInTerm()
    {
        double distance;
        double x1 = 0;
        double z1 = 0;
        double x2;
        double z2;
        int checkTerm = -1;

        if (nowCharecter != null)
        {
            x1 = nowCharecter.transform.position.x;
            z1 = nowCharecter.transform.position.z;
        }

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
            else if (State == "Choose a enemy character" || State == "Use skills with enemies")
            {
                checkTerm = nowCharecter.attackRange;
            }
            foreach (GameObject floor in allFloor)
            {
                x2 = floor.transform.position.x;
                z2 = floor.transform.position.z;
                distance = (Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((z1 - z2), 2)));
                //Debug.Log("Distance: " + distance + " px");
                if (distance != 0 && distance <= (checkTerm * 6))//6 = scale of floor(px)
                {
                    floor.GetComponent<Floor>().InTerm = true;
                }
            }
        }
    }
    public void botChackInTerm()//test
    {
        double distance;
        double x1 = nowCharecter.transform.position.x;
        double z1 = nowCharecter.transform.position.z;
        double x2;
        double z2;
        allFloorInTerm.Clear();
        int checkTerm = nowCharecter.walkingDistance;
        foreach (GameObject floor in allFloor)
        {
            x2 = floor.transform.position.x;
            z2 = floor.transform.position.z;
            distance = (Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((z1 - z2), 2))) / 6;//6 = scale of floor(px)
            //Debug.Log("Distance: " + distance + " px");
            if (checkTerm >= distance && distance != 0)
            {
                allFloorInTerm.Add(floor);
                //floor.GetComponent<Floor>().InTerm = true;
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
    public int Turn
    {
        get { return turn; }
        set { turn = value; }
    }
    
}
