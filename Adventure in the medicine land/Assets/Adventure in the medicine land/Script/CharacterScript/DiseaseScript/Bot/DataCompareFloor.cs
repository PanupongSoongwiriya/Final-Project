using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataCompareFloor : MonoBehaviour
{
    public Floor floor;
    public int index;
    public float priority;
    public float distanceFromEnemy;
    public float distanceFromOnself;
    public bool enemyWithinWalkDistance;

    public DataCompareFloor createData(Floor floor, int priority, int index)
    {
        this.floor = floor;
        this.index = index;
        enemyWithinWalkDistance = false;
        Priority = priority;

        return this;
    }
    public float dataType(String type)
    {
        if (type.Equals("Enemy"))
        {
            return distanceFromEnemy;
        }else if (type.Equals("Self"))
        {
            return distanceFromOnself;
        }
        return priority;
    }


    public float Priority
    {
        get { return priority; }
        set { priority = value; }
    }
}
