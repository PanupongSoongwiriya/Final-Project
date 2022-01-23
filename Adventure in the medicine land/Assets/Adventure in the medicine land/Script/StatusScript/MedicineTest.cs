using System.Collections;
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

        /**************************************************/
        if (s == null || s.statusType.Equals("heal"))
        {
            return true;
        }
        /**************************************************/
        /*if (s.Type.Equals("acne"))
        {
            return true;
        }*/
        if (s.statusType.Equals("disease"))
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
}
