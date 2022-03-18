using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnimetion : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Character c;
    [SerializeField]
    protected bool test;


    void Start()
    {
        animator = GetComponent<Animator>();
        c = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
            //animator.SetBool("Walk", true);
            animator.SetBool("GetHit", true);
            Debug.Log("TEST 444444444444444444444444444444444444444444444444444444444");
            StartCoroutine(SetAnimBool("GetHit", false));
            Debug.Log("TEST 5555555555555555555555555555555555555555555555555555555555");
            //animator.SetBool("Walk", false);
            //animator.SetBool("Attack", false);
        
    }

    IEnumerator SetAnimBool(string var, bool b)
    {
        Debug.Log("TEST 11111111111111111111111111111111111111111111111111111111111111");
        yield return new WaitForSeconds(0.25f);
        animator.SetBool(var, b);
        Debug.Log("TEST 22222222222222222222222222222222222222222222222222222222222222");
    }
}
