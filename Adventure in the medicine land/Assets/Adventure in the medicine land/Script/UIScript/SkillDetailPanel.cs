using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetailPanel : MonoBehaviour
{
    public int numberOfSkill;
    public GameObject skillPanel_1;
    public GameObject skillPanel_2;
    public GameObject skillPanel_3;
    public GameSystem gameSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showDetail();
    }
    private void showDetail()
    {
        skillPanel_1.gameObject.SetActive(numberOfSkill > 0);
        skillPanel_2.gameObject.SetActive(numberOfSkill > 1);
        skillPanel_3.gameObject.SetActive(numberOfSkill > 2);
        if (numberOfSkill > 0)
        {
            GameObject.Find("Skill_1").GetComponentsInChildren<Text>()[0].text = gameSystem.NowCharecter.allSkill[0].SkillName;
            GameObject.Find("Skill_1").GetComponentsInChildren<Text>()[1].text = gameSystem.NowCharecter.allSkill[0].DesCripTion;
        }
        if (numberOfSkill > 1)
        {
            GameObject.Find("Skill_2").GetComponentsInChildren<Text>()[0].text = gameSystem.NowCharecter.allSkill[1].SkillName;
            GameObject.Find("Skill_2").GetComponentsInChildren<Text>()[1].text = gameSystem.NowCharecter.allSkill[1].DesCripTion;
        }
        if (numberOfSkill > 2)
        {
            GameObject.Find("Skill_3").GetComponentsInChildren<Text>()[0].text = gameSystem.NowCharecter.allSkill[2].SkillName;
            GameObject.Find("Skill_3").GetComponentsInChildren<Text>()[1].text = gameSystem.NowCharecter.allSkill[2].DesCripTion;
        }
    }
}
