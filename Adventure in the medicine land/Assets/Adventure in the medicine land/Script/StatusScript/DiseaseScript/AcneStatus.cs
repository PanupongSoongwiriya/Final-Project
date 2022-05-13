using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcneStatus : Status
{
    void Start()
    {
        startSet("โรคสิว", "", "disease", "Acne", 0, 0, new Color(1, 0, 0, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            if (c.THE_REAL_MAX_HP == c.MAXHP)
            {
                c.hp = Mathf.Min((int)Mathf.Round(c.MAXHP * 0.75f), c.hp);
                c.MAXHP = (int)Mathf.Round(c.MAXHP * 0.75f);
            }
        }
    }

    public override void retrospectiveStatus(Character c)
    {
        c.MAXHP = c.THE_REAL_MAX_HP;
    }

    public override bool IsStatusEffective(Status s)
    {
        if (s == null)
        {
            return true;
        }
        else if (s.Type.Equals("Cure Acne") || s.statusType.Equals("disease"))
        {
            return false;
        }
        return true;
    }
}
