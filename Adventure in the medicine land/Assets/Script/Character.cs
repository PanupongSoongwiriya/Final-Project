using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{

    private String faction;
    private String classs;

    public int hp;

    public int x;
    public int y;

    private int attackPower;
    private int specialAttack;

    public int defensePower;
    public int specialDefense;

    private int walkingDistance;
    private int attackRange;

    public Character(String faction, String classs, int x, int y)
    {
        this.faction = faction;
        this.classs = classs;

        this.hp = 0;

        this.x = x;
        this.y = y;

        this.attackPower = 0;
        this.specialAttack = 0;

        this.defensePower = 0;
        this.specialDefense = 0;

        this.walkingDistance = 0;
        this.attackRange = 0;
    }

    void Start()
    {
    }

    void Update()
    {

    }
    private void attack()
    {
    }
    private void walk()
    {
    }
    private void useSkill()
    {
    }
    private void defense()
    {
        specialDefense += 1;
    }
}
