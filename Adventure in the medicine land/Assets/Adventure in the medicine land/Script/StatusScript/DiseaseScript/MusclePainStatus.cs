using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusclePainStatus : Status
{
    void Start()
    {
        startSet("ปวดกล้ามเนื้อ", "", "disease", "MusclePain", -1, 0, new Color(1, 0, 0, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            c.walkingDistance += numEffect;
        }
    }

    public override void retrospectiveStatus(Character c)
    {
        c.walkingDistance -= numEffect;
    }

    public override bool IsStatusEffective(Status s)
    {
        if (s == null)
        {
            return true;
        }
        else if (s.Type.Equals("Cure MusclePain") || s.statusType.Equals("disease"))
        {
            return false;
        }
        return true;
    }
}
