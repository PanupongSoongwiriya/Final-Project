using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomachacheStatus : Status
{
    void Start()
    {
        startSet("ปวดท้อง", "", "disease", "Stomachache", 3, 0, new Color(1, 0, 0, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            c.SP_Atk -= numEffect;
        }
    }

    public override void retrospectiveStatus(Character c)
    {
        c.SP_Atk += numEffect;
    }

    public override bool IsStatusEffective(Status s)
    {
        if (s == null)
        {
            return true;
        }
        else if (s.Type.Equals("Cure Stomachache") || s.statusType.Equals("disease"))
        {
            return false;
        }
        return true;
    }
}
