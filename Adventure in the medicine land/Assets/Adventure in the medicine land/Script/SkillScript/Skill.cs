using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill : MonoBehaviour
{
    protected String skillName;
    protected String desCripTion;
    protected GameSystem gameSystem;
    protected int bonusEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void changeState()
    {
    }
    public virtual void cancelSkill()
    {
    }

    public String SkillName
    {
        get { return skillName; }
        set { skillName = value; }
    }
    public String DesCripTion
    {
        get { return desCripTion; }
        set { desCripTion = value; }
    }
}
