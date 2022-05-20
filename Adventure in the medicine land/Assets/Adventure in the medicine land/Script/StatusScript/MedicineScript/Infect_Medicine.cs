using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infect_Medicine : Status
{
    // Start is called before the first frame update
    void Start()
    {
        startSet("ยาฆ่าเชื้อ", "ใช้รักษาสถานะติดเชื้อ(ลดพลังชีวิตลง 10%)", "heal", "Cure Infect", 0, 0, new Color(1, 1, 1, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }
    public override bool IsStatusEffective(Status s)
    {

        if (s == null || s.statusType.Equals("heal"))
        {
            return true;
        }
        if (s.Type.Equals("Infect"))
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
