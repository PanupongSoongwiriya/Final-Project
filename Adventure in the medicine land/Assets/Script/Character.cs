using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{

    public String faction;
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

    private GameObject targetSquare;

    public GameObject system;
    private GameSystem gameSystem;

    public GameObject controlPanel;

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
        gameSystem = system.GetComponent<GameSystem>();
        //faction = "Player";
        //hp = 2;
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        if (gameSystem.State.Equals("Choose a player character") && faction.Equals("Player"))
        {
            gameSystem.Player = this;
            gameSystem.State = "waiting for orders";
            Debug.Log(gameSystem.State);
            controlPanel.gameObject.SetActive(true);
        }else if (gameSystem.State.Equals("Choose a enemy character") && !gameSystem.Player.Faction.Equals(faction))
        {
            controlPanel.gameObject.SetActive(false);
            hp -= 1;
            gameSystem.State = "Choose a player character";
            Debug.Log(gameSystem.State);
            checkHP();
        }
    }
    private void attack()
    {
        SelectSquare();
    }
    private void walk()
    {
        SelectSquare();
    }
    private void useSkill()
    {
    }
    private void defense()
    {
        specialDefense += 1;
    }
    private void SelectSquare()
    {

    }
    private void checkHP()
    {
        if (hp <= 0)
        {
            Debug.Log("Check222222222222222222222222");
            Debug.Log("HP: " + hp);
            Destroy(this.gameObject);
        }

    }
    public String Faction
    {
        get { return faction; }
        set { faction = value; }
    }
}
