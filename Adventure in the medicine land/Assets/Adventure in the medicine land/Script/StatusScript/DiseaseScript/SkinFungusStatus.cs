using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinFungusStatus : Status
{
    void Start()
    {
        startSet("เชื้อราที่ผิวหนัง", "", "disease", "SkinFungus", -1, 0, new Color(1, 0, 0, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            c.attackRange += numEffect;
        }
    }

    public override void retrospectiveStatus(Character c)
    {
        c.attackRange -= numEffect;
    }

    public override bool IsStatusEffective(Status s)
    {
        if (s == null)
        {
            return true;
        }
        else if (s.Type.Equals("Cure SkinFungus") || s.statusType.Equals("disease"))
        {
            return false;
        }
        return true;
    }
}
