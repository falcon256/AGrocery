using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleScript : MonoBehaviour
{
    public Animator playerAnims;

    public int walkSpeed = 5;
    public int runSpeed = 20;
    public int jumpHeight = 1;
    public int count;
    public int directionToTurn;

    public bool closeToPlayer;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        Idle();
    }

    void Idle()
    {
        walkSpeed = 0;
        runSpeed = 0;

        playerAnims.SetBool("isWalkingForward", false);
        playerAnims.SetBool("isRunningForward", false);
    }
}
