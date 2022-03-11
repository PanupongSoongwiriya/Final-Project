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
        walkingDistance = 2;
        attackRange = 3;
    }
}
