using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TutorialSystem : GameSystem
{
    [SerializeField]
    private List<GameObject> buttonDescription;

    [SerializeField]
    private List<GameObject> tdUI;

    [Serializable]
    public struct tutorialDescription
    {
        public string name;
        public string description;
        public bool FP;
        public bool Ccl;
        public bool Ovl;
        public int medicineIndex;
        public int diseaseIndex;
        public int floorIndex;
        public int buttonIndex;
        public int channelMedicineIndex;
        public bool clearAllAP;
        public bool showImage;
        public bool hts;
    }

    [SerializeField]
    private GameObject ForcePress;

    [SerializeField]
    private GameObject Concealed;
    [SerializeField]
    private GameObject Overlay;
    [SerializeField]
    private GameObject General;
    [SerializeField]
    private GameObject DescriptionOject;
    [SerializeField]
    private BagDetailPanel bagOject;
    [SerializeField]
    private GameObject img;
    [SerializeField]
    private GameObject highlightTextStatus;

    [SerializeField]
    private int tutorialStep;
    [SerializeField]
    private tutorialDescription[] Description;
    void Start()
    {
        whoTurn = "Medicine";
        state = "Choose a medicine character";
        turn = 0;
        controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
        //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        cf = GameObject.Find("Game Camera").GetComponent<CameraFollow>();
        TutorialStep = -1;
    }

    private void setTutoria()
    {
        Debug.Log("tutorialStep: " + tutorialStep + "------------------------------");
        if (Description.Length > tutorialStep)
        {
            General.SetActive(Description[tutorialStep].name != "");
            DescriptionOject.SetActive(Description[tutorialStep].description != "");
            DescriptionOject.GetComponentInChildren<Text>().text =  Description[tutorialStep].description;
            ForcePress.SetActive(Description[tutorialStep].FP);
            Concealed.SetActive(Description[tutorialStep].Ccl);
            Overlay.SetActive(Description[tutorialStep].Ovl);
            img.SetActive(Description[tutorialStep].showImage);
            highlightTextStatus.SetActive(Description[tutorialStep].hts);
            clearAllButtonDescription();
            clearTutorialDescription();
            setAllButtonActive(false);
            if (Description[tutorialStep].medicineIndex > -1)
            {
                cf.Target = medicineFaction[Description[tutorialStep].medicineIndex].transform;
            }
            else if (Description[tutorialStep].diseaseIndex > -1)
            {
                cf.Target = diseaseFaction[Description[tutorialStep].diseaseIndex].transform;
            }
            else if (Description[tutorialStep].floorIndex > -1)
            {
                cf.Target = allFloor[Description[tutorialStep].floorIndex-1].transform;
            }
            else if (Description[tutorialStep].buttonIndex > -1)
            {
                if (Description[tutorialStep].buttonIndex == 4)
                {
                    GameObject cancelBtn = controlPanel.transform.GetChild(1).gameObject;
                    cancelBtn.GetComponent<controlPanelButton>().ActiveBotton = true;
                }
                else
                {
                    GameObject OptionsPanel = controlPanel.transform.GetChild(0).gameObject;
                    OptionsPanel.transform.GetChild(Description[tutorialStep].buttonIndex).GetComponent<controlPanelButton>().ActiveBotton = true;
                }
            }
            if (Description[tutorialStep].clearAllAP)
            {
                for (int i = 0; i < medicineFaction.Count; i++)
                {
                    medicineFaction[i].ActionPoint = 0;
                }
                checkChangeTurn();
            }
            if (Description[tutorialStep].channelMedicineIndex > -1)
            {
                bagOject.setActiveChannel(Description[tutorialStep].channelMedicineIndex);
            }
        }
        else
        {
            General.SetActive(false);
            DescriptionOject.SetActive(false);
            ForcePress.SetActive(false);
            Concealed.SetActive(false);
            Overlay.SetActive(false);
            img.SetActive(false);
            clearAllButtonDescription();
            clearTutorialDescription();
            setAllButtonActive(true);
        }
    }

    void Update()
    {
        if (tutorialStep == -1 & medicineFaction.Count != 0)
        {
            foreach (Character medicine in medicineFaction)
            {
                TutorialStep = 0;
            }
        }
        if (tutorialStep < Description.Length)
        {
            lockCamera = true;
        }
        else
        {
            lockCamera = false;
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
        //TutorialStep = -1;
    }
    private void clearTutorialDescription()
    {
        for (int i = 0; i < tdUI.Count; ++i)
        {
            tdUI[i].SetActive(false);
        }
}

private void clearAllButtonDescription()
{
    foreach (GameObject button in buttonDescription)
    {
        button.SetActive(false);
    }
}
private void setAllButtonActive(bool active)
{
        GameObject OptionsPanel = controlPanel.transform.GetChild(0).gameObject;
        for (int i = 0; i < OptionsPanel.transform.childCount; ++i)
        {
            OptionsPanel.transform.GetChild(i).GetComponent<controlPanelButton>().ActiveBotton = active;
        }
        GameObject cancelBtn = controlPanel.transform.GetChild(1).gameObject;
        cancelBtn.GetComponent<controlPanelButton>().ActiveBotton = active;
        //controlPanel.transform.GetChild(2).GetComponent<controlPanelButton>().ActiveBotton = active;
    }

public int TutorialStep
{
    get { return tutorialStep; }
    set { 
            tutorialStep = Mathf.Min(value, Description.Length);
            if (value > -1)
            {
                setTutoria();
            }
        }
}

}
