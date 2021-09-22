using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class characterDetailPanel : MonoBehaviour
{
    public Text nameText;
    public Text classText;
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
        nameText.text = "Name: " + gameSystem.NowCharecter.characterName;

        if (gameSystem.NowCharecter.Faction.Equals("Disease"))
        {
            nameText.text += " " + gameSystem.NowCharecter.ID;
        }

        classText.text = "Class: " + gameSystem.NowCharecter.classCharacter;
        hpText.text = "Hp: " + gameSystem.NowCharecter.hp;

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

        atkText.text = "Atk: " + gameSystem.NowCharecter.attackPower + spATK;
        defText.text = "Def: " + gameSystem.NowCharecter.defensePower + spDEF;
    }
}
