using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour
{
    public Animator playerAnims;

    public int walkSpeed = 5;
    public int runSpeed = 20;
    public int jumpHeight = 1;
    public int count = 0;
    public int directionToTurn;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        count++;

        if (count == 100)
        {
            directionToTurn = Random.Range(0, 4);
            Wander();
        }

        if (directionToTurn == 0)
        {
            transform.position += transform.forward * Time.deltaTime * walkSpeed;
            transform.rotation = transform.rotation;
            //Debug.Log("Forward");
        }
        else if (directionToTurn == 1)
        {
            transform.position += -transform.forward * Time.deltaTime * walkSpeed;
            transform.rotation = transform.rotation;
            //Debug.Log("Backward");
        }
        else if (directionToTurn == 2)
        {
            transform.position += transform.right * Time.deltaTime * walkSpeed;
            transform.rotation = transform.rotation;
            //Debug.Log("Right");
        }
        else if (directionToTurn == 3)
        {
            transform.position += -transform.right * Time.deltaTime * walkSpeed;
            transform.rotation = transform.rotation;
            //Debug.Log("Left");
        }

        playerAnims.SetBool("isWalkingForward", true);
    }
    void Wander()
    {
        count = 0;
        walkSpeed = 10;
        runSpeed = 20;
    }
}

