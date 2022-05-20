using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InfectStatus : Status
{
    Character chr;

    void Start()
    {
        startSet("ติดเชื้อ", "", "disease", "Infect", 0, 0, new Color(1, 0, 0, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            chr = null;
            chr = c;
            c.HP(Math.Min((int)-(c.hp*0.1f), -1));
            Invoke("delayShowPoison", 1f);
        }
    }

    private void delayShowPoison()
    {
        chr.showDMG(Math.Min((int)-(chr.hp * 0.1f), -1), "poison");
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
