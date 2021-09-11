using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
        if (numberOfSkill > 1)
        {
        }
        if (numberOfSkill > 2)
        {
        }
    }
}
