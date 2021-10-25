using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSystem : GameSystem
{
    public GameObject tutoria;
    public int tutorialStep = 0;
    public bool firstDiseaseTurn = false;
    void Start()
    {
        whoTurn = "Medicine";
        state = "Choose a medicine character";
        turn = 0;
        controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
        //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        cf = GameObject.Find("Game Camera").GetComponent<CameraFollow>();
        tutoria = GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount-1).gameObject;
        Debug.Log(tutoria.transform.GetChild(0).name);
        
    }

    private void setTutoria()
    {
        for (int i = 0; i < tutoria.transform.childCount; i++)
        {
            tutoria.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (tutorialStep < tutoria.transform.childCount)
        {
            tutoria.transform.GetChild(tutorialStep).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        for (int i = 0; i < tutoria.transform.childCount; i++)
        {
            tutoria.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (tutorialStep < tutoria.transform.childCount)
        {
            tutoria.transform.GetChild(tutorialStep).gameObject.SetActive(true);
        }
    }

    public override void resetGame()
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
        tutorialStep = 0;
    }
    protected override void setBoolTurn()
    {
        firstDiseaseTurn = WhoTurn.Equals("Disease") && Turn == 0;
    }

    public int TutorialStep
    {
        get { return tutorialStep; }
        set { tutorialStep = value; setTutoria(); }
    }

}
