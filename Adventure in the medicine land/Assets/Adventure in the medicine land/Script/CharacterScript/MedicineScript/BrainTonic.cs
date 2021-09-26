using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainTonic : Character
{
    void Start()
    {
        characterName = "Ginkgo";
        faction = "Medicine";
        classCharacter = "บำรุงสมอง";
        genusPhase = "ระยะไกล";

        HP = 10;
        attackPower = 2;
        defensePower = 1;


        startSetUp();

        GameObject skill = new GameObject();
        skill.name = name + " Skill";
        skill.AddComponent<BootATK>().gameSystem = gameSystem;
        skill.AddComponent<BootDEF>().gameSystem = gameSystem;
        allSkill.Add(skill.GetComponent<BootATK>());
        allSkill.Add(skill.GetComponent<BootDEF>());
    }

    void OnMouseDown()
    {
        allAction();
    }
    protected override void resetRange()
    {
        walkingDistance = 2;
        attackRange = 3;
    }
}
