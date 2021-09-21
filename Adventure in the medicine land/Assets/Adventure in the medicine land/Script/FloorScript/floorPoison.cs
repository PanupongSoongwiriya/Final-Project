using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorPoison : Floor
{
    public int poison = 1;
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        setTypeFloor();
    }

    protected override void setTypeFloor()
    {
        floorColor = new Color(0.5019608f, 0f, 0.5019608f, 1f);
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            characterOnIt = collision.gameObject.GetComponent<Character>();
            characterOnIt.PedalFloor = this;
            characterOnIt.showDMG(-poison);
            characterOnIt.HP -= poison;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
    }
    private void OnCollisionExit(Collision collision)
    {
        characterOnIt = null;
    }
    public override void floorEffect()
{
        if (characterOnIt != null)
        {
            characterOnIt.showDMG(-poison);
            characterOnIt.HP -= poison;
        }
    }
}
