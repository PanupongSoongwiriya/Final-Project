using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnyNose_Medicine : Status
{

    void Start()
    {
        startSet("ยาลดน้ำมูก", "ใช้รักษาสถานะน้ำมูกไหล(ลดพลังป้องกันลง 3 หน่วย)", "heal", "Cure RunnyNose", 0, 0, new Color(1, 1, 1, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }
    public override bool IsStatusEffective(Status s)
    {

        if (s == null || s.statusType.Equals("heal"))
        {
            return true;
        }
        if (s.Type.Equals("RunnyNose"))
        {
            return true;
        }
        return false;
    }
    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            c.characterStatus = null;
        }
    }
    public override void retrospectiveStatus(Character c)
    {
        overDosage(c);
    }
}
