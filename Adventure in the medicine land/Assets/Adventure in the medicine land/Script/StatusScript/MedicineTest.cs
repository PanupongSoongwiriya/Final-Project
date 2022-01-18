﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineTest : Status
{
    // Start is called before the first frame update
    void Start()
    {
        startSet("ยาอายุวัฒนะ", "เป็นยาที่สามารถรักษาโรคได้ทุกโรค", "heal", "cure all disease", 0, 0, new Color(1, 1, 1, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }
    public override bool IsStatusEffective(Status s)
    {
        /*if (s.Type.Equals(""))
        {
            return true;
        }*/

        /**************************************************/
        if (s == null  || s.statusType.Equals("heal") || s.statusType.Equals("disease"))
        {
            return true;
        }
        /**************************************************/
        return false;
    }
    public override void statusEffect()
    {
        if (chr != null & chr.Faction.Equals("Medicine"))
        {
            chr.characterStatus = null;
        }
    }
}
