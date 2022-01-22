using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStatus : Status
{
    // Start is called before the first frame update
    void Start()
    {
        startSet("โรคสิว", "", "disease", "acne", 1, 0, new Color(1, 0, 0, 1));
        //name, Description, status type, effect type, numEffect, numEffect_2, color
    }

    public override void statusEffect(Character c)
    {
        if (c.Faction.Equals("Medicine"))
        {
            //c.HP -= numEffect; c.showDMG(-numEffect, "poison");
            //c.SP_Atk -= numEffect;
            c.SP_Def -= numEffect;
            //c.walkingDistance -= numEffect;
            //c.attackRange -= numEffect;
        }
    }
    public override bool IsStatusEffective(Status s)
    {
        /*if (s.Type.Equals(""))
        {
            return true;
        }*/

        /**************************************************/
        if (s == null)
        {
            return true;
        }
        else if (s.Type.Equals("cure all disease"))
        {
            return false;
        }
        /**************************************************/
        return true;
    }
}
