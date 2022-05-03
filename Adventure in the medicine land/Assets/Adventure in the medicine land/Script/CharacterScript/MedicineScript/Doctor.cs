using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Doctor : Character
{
    void Start()
    {
        characterName = "โฮพ";
        faction = "Medicine";
        classCharacter = "หมอ";
        soundAttackType = "Blow";

        hp = 50;
        attackPower = 30;
        defensePower = 10;

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
        countSetCharacterOnIt();
    }
    void OnMouseDown()
    {
        allAction();
    }
    protected override void resetRange()
    {
        attackRange = 1;
        walkingDistance = 3;
        cureRange = 2;
    }
}
