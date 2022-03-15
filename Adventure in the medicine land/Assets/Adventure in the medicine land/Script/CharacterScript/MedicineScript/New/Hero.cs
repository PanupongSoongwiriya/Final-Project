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
        classCharacter = "ผู้หล้า";

        attackPower = 3;
        defensePower = 3;
        HP = 3;

        startSetUp();

        bag.Add(status.GetComponent<Acne_Medicine>());
        bag.Add(status.GetComponent<Headache_Medicine>());
        bag.Add(status.GetComponent<Infect_Medicine>());
        bag.Add(status.GetComponent<Itching_Medicine>());
        bag.Add(status.GetComponent<MusclePain_Medicine>());
        bag.Add(status.GetComponent<RunnyNose_Medicine>());
        bag.Add(status.GetComponent<SkinFungus_Medicine>());
        bag.Add(status.GetComponent<Stomachache_Medicine>());
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
        attackRange = 2;
        walkingDistance = 3;
    }
}
