using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class characterDetailPanel : MonoBehaviour
{
    public Text nameText;
    public Text classText;
    public Text statusText;
    public Text hpText;
    public Text atkText;
    public Text defText;

    public GameObject system;
    protected GameSystem gameSystem;
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
    }

    void Update()
    {
        setText();
    }

    private void setText()
    {
        String spATK = " (";
        String spDEF = " (";
        nameText.text = "ชื่อ: " + gameSystem.NowCharecter.characterName;

        if (gameSystem.NowCharecter.Faction.Equals("Disease"))
        {
            nameText.text += " " + gameSystem.NowCharecter.ID;
        }

        classText.text = "คลาส: " + gameSystem.NowCharecter.classCharacter;

        if (gameSystem.NowCharecter.Faction.Equals("Disease"))
        {
            statusText.text = "";
        }
        else
        {
            if (gameSystem.NowCharecter.CharacterStatus == null)
            {
                statusText.text = "สถานะ: ปกติ";
            }
            else
            {
                statusText.text = "สถานะ: " + gameSystem.NowCharecter.CharacterStatus.statusName;
            }
        }

        hpText.text = "พลังชีวิต: " + gameSystem.NowCharecter.hp + "/" + gameSystem.NowCharecter.MAXHP;

        if (gameSystem.NowCharecter.specialAttack > 0)
        {
            spATK += "+" + gameSystem.NowCharecter.specialAttack + ")";
        }
        else
        {
            spATK += gameSystem.NowCharecter.specialAttack + ")";
        }

        if (gameSystem.NowCharecter.specialDefense > 0)
        {
            spDEF += "+" + gameSystem.NowCharecter.specialDefense + ")";
        }
        else
        {
            spDEF += gameSystem.NowCharecter.specialDefense + ")";
        }

        atkText.text = "พลังโจมตี: " + gameSystem.NowCharecter.attackPower + spATK;
        defText.text = "พลังป้องกัน: " + gameSystem.NowCharecter.defensePower + spDEF;
    }
}
