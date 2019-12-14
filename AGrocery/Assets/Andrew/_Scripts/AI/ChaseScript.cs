using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
    public Transform player;

    public Animator playerAnims;

    public int walkSpeed = 5;
    public int runSpeed = 20;
    public int jumpHeight = 1;
    public int count = 0;

    public bool closeToPlayer = false;
    public bool awayFromPlayer = false;
    public bool tooFarFromPlayer = false;
    public bool followingPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Chase();
    }

    void Chase()
    {

        float dist = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(dist);
        if (dist <= 10.0f)
        {
            closeToPlayer = true;
        }
        else
        {
            closeToPlayer = false;
        }

        if (dist >= 10.0f)
        {
            awayFromPlayer = true;
        }
        else
        {
            awayFromPlayer = false;
        }

        if (awayFromPlayer)
        {
            walkSpeed = 5;
            runSpeed = 20;
            transform.position = Vector3.MoveTowards(transform.position,
            player.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardPlayer = new Vector3(player.transform.position.x,
            transform.position.y, player.transform.position.z);
            transform.LookAt(rotateTowardPlayer);
            playerAnims.SetBool("isWalkingForward", true);
            playerAnims.SetBool("isRunningForward", false);
        }
        if (closeToPlayer)
        {
            walkSpeed = 0;
            runSpeed = 0;
            Vector3 rotateTowardPlayer = new Vector3(player.transform.position.x,
            transform.position.y, player.transform.position.z);
            transform.LookAt(rotateTowardPlayer);
            playerAnims.SetBool("isWalkingForward", false);
            playerAnims.SetBool("isRunningForward", false);
        }
    }
}