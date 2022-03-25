using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BotDisease : MonoBehaviour
{
    public Character chr;
    public Character target;
    public GameSystem gameSystem;
    public String stage;
    public List<DataCompareFloor> priorityFloor = new List<DataCompareFloor>();
    public List<DataCompareMedicine> priorityMedicine = new List<DataCompareMedicine>();
    public GameObject dataMedicine;
    public GameObject dataFloor;
    public void botActive()
    {
        deleteData();
        dataMedicine = new GameObject("Data Medicine: " + chr.classCharacter + " " + chr.ID);
        dataFloor = new GameObject("Data Floor: " + chr.classCharacter + " " + chr.ID);
        priorityMedicine = new List<DataCompareMedicine>();
        priorityFloor = new List<DataCompareFloor>();
        gameSystem.cf.Target = transform;
        stage = "walk";
        target = null;
        int index = 0;
        foreach (Character medicine in gameSystem.medicineFaction)
        {
            int dmg = medicine.calculateDMG(chr, medicine);
            int inflictDamage = dmg;

            bool canKill = (medicine.hp - inflictDamage) <= 0;

            dmg = medicine.calculateDMG(medicine, chr); 
            int damaged = dmg;

            bool dead = (chr.hp - damaged) <= 0;

            Vector3 medicinePosition = medicine.transform.position;
            Vector3 chrPosition = chr.transform.position;
            float distance = findDistance(medicinePosition, chrPosition);
            float howFar = distance;

            gameSystem.NowCharecter = medicine;
            gameSystem.findDistance(medicine.attackRange, "bad for the enemy");
            bool inRangeMedicine = chr.pedalFloor.inTerm;
            gameSystem.resetInTerm();

            gameSystem.NowCharecter = chr;
            gameSystem.findDistance(chr.attackRange, "bad for the enemy");
            bool inAtkRange = medicine.pedalFloor.inTerm;
            gameSystem.resetInTerm();

            priorityMedicine.Add(dataMedicine.AddComponent<DataCompareMedicine>().createData(medicine, inflictDamage, canKill, damaged, dead, howFar, inRangeMedicine, inAtkRange, medicine.taunts, 0, index));
            ++index;
        }
    }
    public void botWork()
    {
        foreach (DataCompareMedicine medicine in priorityMedicine)
        {
            if (medicine.withinAtkRange && medicine.canKill)
            {
                stage = "attack";
                target = medicine.character;
                break;
            }
            else if (medicine.youDead)
            {
                medicine.priority--;
                if (medicine.withinMedicineAtkRange)
                {
                    stage = "escape";
                    medicine.priority -= 3;
                }
            }
            else if (medicine.taunts)
            {
                medicine.priority -= 3;
            }
        }

        sortPriorityMedicine("inflictDamage");
        sortPriorityMedicine("damaged");
        sortPriorityMedicine("howFar");
        sortPriorityMedicine("priority");

        if (!stage.Equals("escape"))
        {
            gameSystem.botChackInTerm(gameSystem.NowCharecter.attackRange, "bad for the enemy");
            if (gameSystem.allMedicineInTerm.Count != 0)
            {
                if(target == null)
                {
                    target = priorityMedicine[0].character;
                }
                botAttack();
            }
        }
        if (!stage.Equals("attack"))
        {
            int index = 0;
            gameSystem.botChackInTerm(gameSystem.NowCharecter.walkingDistance, "walk");
            foreach (GameObject floor in gameSystem.allFloorInTerm)
            {
                priorityFloor.Add(dataFloor.AddComponent<DataCompareFloor>().createData(floor.GetComponent<Floor>(), 0, index));
                ++index;
            }
            gameSystem.resetInTerm();
            target = priorityMedicine[0].character;
            botWalk();
        }
    }

    private void botWalk()
    {
        //find Floor distance 
        foreach (DataCompareFloor Floor in priorityFloor)
        {
            Vector3 targetPosition = target.transform.position;
            Vector3 selfPosition = chr.transform.position;
            Vector3 floorPosition = Floor.floor.transform.position;
            Floor.distanceFromEnemy = findDistance(targetPosition, floorPosition);
            Floor.distanceFromOnself = findDistance(selfPosition, floorPosition);
        }

        if (!stage.Equals("escape"))
        {
            sortPriorityFloor("Self");
        }

        sortPriorityFloor("Enemy");

        sortPriorityFloor("priority");

        chr.PedalFloor = priorityFloor[0].floor;
    }
    private void botAttack()
    {
        foreach (Character medicine in gameSystem.allMedicineInTerm)
        {
            if (target.Equals(medicine))
            {
                stage = "attack";
                target.attacked();
                spreadGerms();
                break;
            }
        }
    }

    public void afterWolk()
    {
        gameSystem.botChackInTerm(gameSystem.NowCharecter.attackRange, "bad for the enemy");
        if (gameSystem.allMedicineInTerm.Count != 0)
        {
            Character atked = gameSystem.allMedicineInTerm[0];
            for (int i = 1; i < gameSystem.allMedicineInTerm.Count; i++)
            {
                if (atked.hp > gameSystem.allMedicineInTerm[i].hp)
                {
                    atked = gameSystem.allMedicineInTerm[i];
                }
            }
            stage = "attack";
            target = atked;
            target.attacked();
            spreadGerms();
        }
        else
        {
            //Defense
            stage = "defense";
            chr.SP_Def += 1;
            chr.doneIt(2);
        }
        gameSystem.resetInTerm();
    }

    private void spreadGerms()
    {
        if (chr.characterStatus != null)
        {
            //if (Random.Range(0, 2) == 1) 
            if (1 == 1)
            {
                bool change = false;
                if (target.characterStatus == null)
                {
                    change = true;
                }
                else if (chr.characterStatus.IsStatusEffective(target.CharacterStatus))
                {
                    change = true;
                }
                if (change)
                {
                    Debug.Log(target.name);
                    target.CharacterStatus = chr.characterStatus;
                    //target.CharacterStatus.statusEffect(target);
                }
            }
        }
    }

    private float findDistance(Vector3 position1, Vector3 position2)
    {
        return (float)Math.Sqrt(Math.Pow((position1.x - position2.x), 2) + Math.Pow((position1.z - position2.z), 2)) / 6;
    }

    private void sortPriorityMedicine(String howSort)
    {
        for (int i = 0; i < priorityMedicine.Count - 1; i++)
        {
            for (int j = 0; j < priorityMedicine.Count - 1 - i; j++)
            {
                if (howSort.Equals("inflictDamage"))
                {
                    //sort from most to least
                    if (priorityMedicine[j].dataType(howSort) < priorityMedicine[j + 1].dataType(howSort))
                    {
                        DataCompareMedicine swapData = priorityMedicine[j + 1];
                        priorityMedicine[j + 1] = priorityMedicine[j];
                        priorityMedicine[j] = swapData;
                    }
                }
                else
                {
                    //sort from least to most
                    if (priorityMedicine[j].dataType(howSort) > priorityMedicine[j + 1].dataType(howSort))
                    {
                        DataCompareMedicine swapData = priorityMedicine[j];
                        priorityMedicine[j] = priorityMedicine[j + 1];
                        priorityMedicine[j + 1] = swapData;
                    }
                }
            }
        }
        if (!howSort.Equals("priority"))
        {
            int priority = 0;
            for (int i = 0; i < priorityMedicine.Count; i++)
            {
                if (priorityMedicine[Math.Max(i-1, 0)].dataType(howSort) == priorityMedicine[i].dataType(howSort))
                {
                    priorityMedicine[i].Priority += priority;
                }
                else
                {
                    ++priority;
                    priorityMedicine[i].Priority += priority;
                }
                priorityMedicine[i].index = i;
            }
        }
    }
    private void sortPriorityFloor(String howSort)
    {
        // sort distance
        for (int i = 0; i < priorityFloor.Count - 1; i++)
        {
            for (int j = 0; j < priorityFloor.Count - 1 - i; j++)
            {
                if (stage.Equals("escape") && !howSort.Equals("priority"))
                {
                    //sort from  most to least
                    if (priorityFloor[j].dataType(howSort) < priorityFloor[j + 1].dataType(howSort))
                    {
                        DataCompareFloor swapData = priorityFloor[j + 1];
                        priorityFloor[j + 1] = priorityFloor[j];
                        priorityFloor[j] = swapData;
                    }
                }
                else if (stage.Equals("walk"))
                {
                    //sort from least to most
                    if (priorityFloor[j].dataType(howSort) > priorityFloor[j + 1].dataType(howSort))
                    {
                        DataCompareFloor swapData = priorityFloor[j];
                        priorityFloor[j] = priorityFloor[j + 1];
                        priorityFloor[j + 1] = swapData;
                    }
                }
            }
        }
        if (!howSort.Equals("priority"))
        {
            int priority = 0;
            for (int i = 0; i < priorityFloor.Count; i++)
            {
                if (priorityFloor[Math.Max(i - 1, 0)].dataType(howSort) == priorityFloor[i].dataType(howSort))
                {
                    priorityFloor[i].Priority += priority;
                }
                else
                {
                    priority++;
                    priorityFloor[i].Priority += priority;
                }
                priorityFloor[i].index = i;
            }
        }
    }

    public void deleteData()
    {
        Destroy(dataMedicine);
        Destroy(dataFloor);
        priorityFloor.Clear();
        priorityMedicine.Clear();
    }
}
