using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : Character
{
    void Start()
    {
        characterName = "พยาบาล";
        faction = "Medicine";
        classCharacter = "หมอ";
        soundAttackType = "Blow";

        hp = 40;
        attackPower = 35;
        defensePower = 15;

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
        walkingDistance = 3;
        attackRange = 1;
        cureRange = 2;
    }
}
