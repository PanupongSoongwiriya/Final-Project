using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItchingStatus : Status
{
    void Start()
    {
        startSet("อาการคัน", "", "disease", "Itching", 0, 0, new Color(1, 0, 0, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            c.DisableAttack = true;
        }
    }

    public override void retrospectiveStatus(Character c)
    {
        c.DisableAttack = false;
    }

    public override bool IsStatusEffective(Status s)
    {
        if (s == null)
        {
            return true;
        }
        else if (s.Type.Equals("Cure Itching") || s.statusType.Equals("disease"))
        {
            return false;
        }
        return true;
    }
}
