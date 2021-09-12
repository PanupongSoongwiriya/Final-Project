using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    public int numberOfSkill;
    public GameObject skillButton_1;
    public GameObject skillButton_2;
    public GameObject skillButton_3;
    public GameSystem gameSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showButton();
    }

    private void showButton()
    {
        skillButton_1.gameObject.SetActive(numberOfSkill > 0);
        skillButton_2.gameObject.SetActive(numberOfSkill > 1);
        skillButton_3.gameObject.SetActive(numberOfSkill > 2);
        if (numberOfSkill > 0)
        {
            skillButton_1.GetComponentsInChildren<Text>()[0].text = gameSystem.NowCharecter.allSkill[0].SkillName;
        }
        if (numberOfSkill > 1)
        {
            skillButton_2.GetComponentsInChildren<Text>()[0].text = gameSystem.NowCharecter.allSkill[1].SkillName;
        }
        if (numberOfSkill > 2)
        {
            skillButton_3.GetComponentsInChildren<Text>()[0].text = gameSystem.NowCharecter.allSkill[2].SkillName;
        }
    }

    public void activeSkill(int index)
    {
        gameSystem.NowCharecter.useSkill(index);
    }
}
