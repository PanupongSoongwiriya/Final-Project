using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
        if (numberOfSkill > 1)
        {
        }
        if (numberOfSkill > 2)
        {
        }
    }
}
