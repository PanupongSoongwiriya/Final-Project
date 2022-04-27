using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hero : Character
{
    void Start()
    {
        characterName = "โฮพ";
        faction = "Medicine";
        classCharacter = "ผู้กล้า";
        soundAttackType = "Slash";

        hp = 60;
        attackPower = 50;
        defensePower = 20;

        startSetUp();

        bag.Add(status.GetComponent<Acne_Medicine>());
        bag.Add(status.GetComponent<Headache_Medicine>());
        bag.Add(status.GetComponent<Infect_Medicine>());
        bag.Add(status.GetComponent<Itching_Medicine>());
        bag.Add(status.GetComponent<MusclePain_Medicine>());
        bag.Add(status.GetComponent<RunnyNose_Medicine>());
        bag.Add(status.GetComponent<SkinFungus_Medicine>());
        bag.Add(status.GetComponent<Stomachache_Medicine>());
        bag.Add(status.GetComponent<Bandage>());
    }

    void Update()
    {
        moveSmoothly();
        spinToTarget();
    }
    void OnMouseDown()
    {
        allAction();
    }
    protected override void resetRange()
    {
        walkingDistance = 3;
        attackRange = 1;
        cureRange = 3;
    }
}
