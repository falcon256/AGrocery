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
            walkSpeed = 5;
            runSpeed = 20;
            Vector3 rotateTowardPlayer = new Vector3(player.transform.position.x,
            transform.position.y, player.transform.position.z);
            transform.LookAt(rotateTowardPlayer);

        playerAnims.SetBool("isWalkingForward", false);
        playerAnims.SetBool("isRunningForward", false);
    }
}