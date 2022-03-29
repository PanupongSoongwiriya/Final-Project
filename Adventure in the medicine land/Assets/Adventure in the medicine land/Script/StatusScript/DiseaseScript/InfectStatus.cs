﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectStatus : Status
{
    void Start()
    {
        startSet("ติดเชื้อ", "", "disease", "Infect", -1, 0, new Color(1, 0, 0, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            c.HP(-(c.hp*0.05f));
            c.showDMG(-(c.hp*0.05f), "poison");
        }
    }

    public override bool IsStatusEffective(Status s)
    {
        if (s == null)
        {
            return true;
        }
        else if (s.Type.Equals("Cure Infect") || s.statusType.Equals("disease"))
        {
            return false;
        }
        return true;
    }
}
