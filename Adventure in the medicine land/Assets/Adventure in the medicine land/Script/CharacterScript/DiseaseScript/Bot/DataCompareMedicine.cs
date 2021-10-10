using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataCompareMedicine : MonoBehaviour
{
    public Character character;
    public float index;
    public float inflictDamage;
    public bool canKill;
    public float damaged;
    public bool youDead;
    public float howFar;
    public bool withinMedicineAttackRange;
    public float priority;

    public DataCompareMedicine createData(Character chr, float inflictDamage, bool canKill, float damaged, bool dead, float howFar, bool inRange, float priority, float index)
    {
        character = chr;
        this.inflictDamage = inflictDamage;
        this.damaged = damaged;
        youDead = dead;
        this.howFar = howFar;
        withinMedicineAttackRange = inRange;
        Priority = priority;
        this.index = index;
        this.canKill = canKill;

        return this;
    }

    public float dataType(String type)
    {
        if (type.Equals("inflictDamage"))
        {
            return inflictDamage;
        }
        else if (type.Equals("damaged"))
        {
            return damaged;
        }
        else if (type.Equals("howFar"))
        {
            return howFar;
        }
        return priority;
    }

    public float Priority
    {
        get { return priority; }
        set { priority = value; }
    }
}
