using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public int turn;
    public string whoTurn;
    private string state;//("Choose a medicine character", "waiting for orders", "walk", "Choose a enemy character", "waiting for skill", "round of bots")
    private Character nowCharecter;
    public GameObject controlPanel;

    public List<GameObject> allFloor;
    public List<Character> medicineFaction;
    public List<Character> diseaseFaction;
    void Start()
    {
        turn = 0;
        whoTurn = "Medicine";
        state = "Choose a medicine character";
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
                }
            }
        }
        if (statusChangeTurn)
        {
            Debug.Log(whoTurn + " Turn");
            //change whoTurn
            if (whoTurn == "Medicine")
            {
                whoTurn = "Disease";
            }
            else
            {
                whoTurn = "Medicine";
                changeTurn();
            }

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


    public string State
    {
        get { return state; }
        set { state = value; Debug.Log(state); }
    }
    public Character NowCharecter
    {
        get { return nowCharecter; }
        set { nowCharecter = value; }
    }
}
