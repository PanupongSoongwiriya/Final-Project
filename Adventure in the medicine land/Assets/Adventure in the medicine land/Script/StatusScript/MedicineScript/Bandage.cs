using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bandage : Status
{
    void Start()
    {
        startSet("ผ้าพันแผล", "เพิ่มพลังชีวิตให้กับเป้าหมาย", "heal", "Bandage", 25, 0, new Color(1, 1, 1, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            c.showDMG(Math.Min(numEffect, c.MAXHP - c.hp), "heal");
            c.HP(numEffect);
        }
    }

    public override bool IsStatusEffective(Status s)
    {
        return false;
    }
}
