using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnyNoseStatus : Status
{
    void Start()
    {
        startSet("น้ำมูกไหล", "", "disease", "RunnyNose", 3, 0, new Color(1, 0, 0, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            c.SP_Def -= numEffect;
        }
    }

    public override void retrospectiveStatus(Character c)
    {
        c.SP_Def += numEffect;
    }

    public override bool IsStatusEffective(Status s)
    {
        if (s == null)
        {
            return true;
        }
        else if (s.Type.Equals("Cure Runny Nose") || s.statusType.Equals("disease"))
        {
            return false;
        }
        return true;
    }
}
