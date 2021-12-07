using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSystem : GameSystem
{
    [SerializeField]
    private List<GameObject> buttonDescription;

    [SerializeField]
    private List<GameObject> tdUI;

    [SerializeField]
    private List<string> tutorialDescription;

    [SerializeField]
    private GameObject ForcePress;

    [SerializeField]
    private GameObject Concealed;
    [SerializeField]
    private GameObject Overlay;
    
    [SerializeField]
    private int tutorialStep;
    void Start()
    {
        whoTurn = "Medicine";
        state = "Choose a medicine character";
        turn = 0;
        controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
        //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        cf = GameObject.Find("Game Camera").GetComponent<CameraFollow>();
        TutorialStep = -1;
        tutorialDescription.Add("เลือกตัวละครยา");
        tutorialDescription.Add("พื้นที่มีสีฟ้าปรากฏขึ้นคือระยะ\nที่ตัวละครสามารถเดินไปได้");
        tutorialDescription.Add("พื้นที่มีสีแดงปรากฏขึ้นคือระยะที่ตัวละคร\nสามารถสร้างความเสียหายให้กับศัตรูได้");
        tutorialDescription.Add("เลือกตัวละครเชิ้อโรค");
        tutorialDescription.Add("หลังจากที่เดินแล้วตัวละครยังกระทำอย่างอื่นได้อีก 1 อย่างที่ไม่ใช่เดิน");
    }

    private void setTutoria()
    {
        Debug.Log("tutorialStep: " + tutorialStep + "------------------------------");
        ForcePress.SetActive(false);
        Concealed.SetActive(false);
        Overlay.SetActive(false);
        setAllButtonActive(true);
        clearAllButtonDescription();
        clearTutorialDescription();
        if (tutorialStep == 0)
        {
            setTutorialDescription("Bottom", 0);
            lockCamera = true;
            ForcePress.gameObject.SetActive(true);
            cf.Target = medicineFaction[0].transform;
        }
        else if (tutorialStep == 1)
        {
            Concealed.SetActive(true);
            setAllButtonActive(false);
            buttonDescription[0].SetActive(true);
            controlPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<controlPanelButton>().ActiveBotton = true;
        }
        else if (tutorialStep == 2)
        {
            setTutorialDescription("Right", 1);
            setTutorialDescription("Left", 99);
            ForcePress.gameObject.SetActive(true);
            setAllButtonActive(false);
            cf.Target = allFloor[37].transform;
        }
        else if (tutorialStep == 3)
        {
            setTutorialDescription("Right", 4);
            setTutorialDescription("Bottom", 0);
            ForcePress.gameObject.SetActive(true);
            cf.Target = medicineFaction[0].transform;
        }
        else if (tutorialStep == 4)
        {
            Concealed.SetActive(true);
            setAllButtonActive(false);
            buttonDescription[1].SetActive(true);
            controlPanel.transform.GetChild(0).transform.GetChild(2).GetComponent<controlPanelButton>().ActiveBotton = true;
        }
        else if (tutorialStep == 5)
        {
            setTutorialDescription("Bottom", 0);
            ForcePress.gameObject.SetActive(true);
            cf.Target = medicineFaction[1].transform;
        }
        else if (tutorialStep == 6)
        {
            Concealed.SetActive(true);
            setAllButtonActive(false);
            buttonDescription[1].SetActive(true);
            controlPanel.transform.GetChild(0).transform.GetChild(2).GetComponent<controlPanelButton>().ActiveBotton = true;
        }
        else if (tutorialStep == 7)
        {
            lockCamera = true;
            Overlay.SetActive(true);
        }
        else if (tutorialStep == 8)
        {
            setTutorialDescription("Bottom", 0);
            lockCamera = true;
            ForcePress.gameObject.SetActive(true);
            cf.Target = medicineFaction[0].transform;
        }
        else if (tutorialStep == 9)
        {
            Concealed.SetActive(true);
            setAllButtonActive(false);
            buttonDescription[2].SetActive(true);
            controlPanel.transform.GetChild(0).transform.GetChild(1).GetComponent<controlPanelButton>().ActiveBotton = true;
        }
        else if (tutorialStep == 10)
        {
            setTutorialDescription("Right", 2);
            setTutorialDescription("Bottom", 3);
            ForcePress.gameObject.SetActive(true);
            setAllButtonActive(false);
            cf.Target = diseaseFaction[1].transform;
        }
        else if (tutorialStep == 11)
        {
            setTutorialDescription("Bottom", 0);
            ForcePress.gameObject.SetActive(true);
            cf.Target = medicineFaction[1].transform;
        }
        else if (tutorialStep == 12)
        {
            Concealed.SetActive(true);
            setAllButtonActive(false);
            buttonDescription[3].SetActive(true);
            controlPanel.transform.GetChild(0).transform.GetChild(3).GetComponent<controlPanelButton>().ActiveBotton = true;
        }
        else if (tutorialStep == 13)
        {
            Concealed.SetActive(true);
            setAllButtonActive(false);
            buttonDescription[4].SetActive(true);
        }
        else if (tutorialStep == 14)
        {
            setTutorialDescription("Bottom", 3);
            ForcePress.gameObject.SetActive(true);
            setAllButtonActive(false);
            cf.Target = diseaseFaction[0].transform;
        }
    }

    void Update()
    {
        if (tutorialStep == -1 & medicineFaction.Count != 0)
        {
            foreach (Character medicine in medicineFaction)
            {
                if (medicine.name.Equals("ยาแก้ปวดกล้ามเนื้อ 1"))
                {
                    TutorialStep = 0;
                }
            }
        }
        if (tutorialStep <= 14)
        {
            lockCamera = true;
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

    private void setTutorialDescription(string where, int index)
    {
        for (int i = 0; i < tdUI.Count; ++i)
        {
            if (tdUI[i].name.Equals(where))
            {
                tdUI[i].SetActive(true);
                if (!where.Equals("Left"))
                {
                    tdUI[i].GetComponent<Text>().text = ThaiFontAdjuster.Adjust(tutorialDescription[index]);
                }
            }

        }
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
    controlPanel.transform.GetChild(2).GetComponent<controlPanelButton>().ActiveBotton = active;
}

public int TutorialStep
{
    get { return tutorialStep; }
    set { tutorialStep = Mathf.Min(value, 15); setTutoria(); }
}

}
