using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopperAIMultiScriptStates : MonoBehaviour
{
    public Transform player;
    public Transform cashier;
    //public GameObject monster;
    //public GameObject[] monsters;

    public Animator playerAnims;

    public int walkSpeed = 5;
    public int runSpeed = 20;
    public int jumpHeight = 1;
    public static int count = 0;
    public int directionToTurn;

    public bool closeToPlayer = false;
    public bool safeDistance = false;
    public bool idleState = false;
    public bool wanderState = false;
    public bool chaseState = false;  
    public bool returnState = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        cashier = GameObject.FindWithTag("Cashier").transform;
        //monster = GameObject.FindWithTag("Monster");
        //monsters = GameObject.FindGameObjectsWithTag("Monster");

        idleState = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        //Debug.Log("player" + distTocashier);
        if (distToPlayer < 29)
        {
            closeToPlayer = true;
        }
        else
        {
            closeToPlayer = false;
        }

        if (distToPlayer > 30)
        {
            safeDistance = true;
        }
        else
        {
            safeDistance = false;
        }

        if (closeToPlayer)
        {
            ChaseState();
        }
        if(safeDistance)
        {
            stateTimer();
        }
    }

    void stateTimer()
    {
        count++;
        if (count > 100 && idleState)
        {
            WanderState();
            wanderState = true;
            idleState = false;
        }
        if (count > 100 && wanderState)
        {
            IdleState();
            idleState = true;
            wanderState = false;
        }
        if (count > 100 && returnState)
        {
            IdleState();
            idleState = true;
            wanderState = false;
            chaseState = false;
            returnState = false;
        }
        if (count > 100 && chaseState)
        {
            IdleState();
            idleState = true;
            wanderState = false;
            chaseState = false;
            returnState = false;
        }
    }

    void IdleState()
    {

            this.GetComponent<IdleScript>().enabled = true;
            this.GetComponent<WanderScript>().enabled = false;
            this.GetComponent<ChaseScript>().enabled = false;
        this.GetComponent<ReturnScript>().enabled = false;
        count = 0;
        idleState = true;
        wanderState = false;
        returnState = false;
        chaseState = false;
    }
    void ChaseState()
    {
            this.GetComponent<IdleScript>().enabled = false;
            this.GetComponent<WanderScript>().enabled = false;
            this.GetComponent<ChaseScript>().enabled = true;
        this.GetComponent<ReturnScript>().enabled = false;
        count = 0;
        idleState = false;
        wanderState = false;
        returnState = false;
        chaseState = true;
    }
    void ReturnState()
    {

        this.GetComponent<IdleScript>().enabled = false;
        this.GetComponent<WanderScript>().enabled = false;
        this.GetComponent<ChaseScript>().enabled = false;
        this.GetComponent<ReturnScript>().enabled = true;
        count = 0;
        idleState = false;
        wanderState = false;
        returnState = true;
        chaseState = false;
    }
    void WanderState()
    {
            this.GetComponent<IdleScript>().enabled = false;
            this.GetComponent<WanderScript>().enabled = true;
            this.GetComponent<ChaseScript>().enabled = false;
        this.GetComponent<ReturnScript>().enabled = false;
        count = 0;
        idleState = false;
        wanderState = true;
        returnState = false;
        chaseState = false;
    }
    }
