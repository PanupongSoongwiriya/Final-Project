using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Character characterOnIt;
    protected GameSystem gameSystem;
    protected bool inTerm = false;
    protected Color floorColor;
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        setTypeFloor();
    }

    protected virtual void setTypeFloor()
    {
        floorColor = Color.white;
        GetComponent<Renderer>().material.SetColor("_Color", floorColor);
    }
    void OnMouseDown()
    {
        if (gameSystem.State.Equals("walk") && inTerm)
        {
            setPositionCharacter();
        }
    }

    protected void showInTerm()
    {
        GameObject show = transform.GetChild(0).gameObject;
        show.SetActive(inTerm);
        if (gameSystem.State == "walk")
        {
            show.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 1, 0.25f));
        }
        else if(gameSystem.State == "Use skills with ally")
        {
            show.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 1, 0, 0.25f));
        }
        else if (gameSystem.State == "Choose a enemy character" || gameSystem.State == "Use skills with enemies" || gameSystem.State == "Debuff with enemies")
        {
            show.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0, 0.5f));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine" || collision.gameObject.tag == "Disease")
        {
            characterOnIt = collision.gameObject.GetComponent<Character>();
            characterOnIt.PedalFloor = this;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        characterOnIt = null;
    }

    public virtual void floorEffect()
    {
        if (characterOnIt != null)
        {
            characterOnIt.specialDefense = 0;
            characterOnIt.specialAttack = 0;
        }
    }

    public void setPositionCharacter()
    {
        gameSystem.NowCharecter.transform.position = new Vector3(transform.position.x, gameSystem.NowCharecter.transform.position.y, transform.position.z);//getposition for move Character
        gameSystem.resetInTerm();
        gameSystem.controlPanel.GetComponent<controlPanelButton>().switchPanel(false, true, false, false, false);
        //controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        gameSystem.NowCharecter.doneIt();
    }

    public bool InTerm
    {
        get { return inTerm; }
        set { inTerm = value; showInTerm(); }
    }
}
