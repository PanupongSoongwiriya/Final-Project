using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill : MonoBehaviour
{
    protected String skillName;
    protected String desCripTion;
    protected int bonusEffect;
    public GameSystem gameSystem;
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
