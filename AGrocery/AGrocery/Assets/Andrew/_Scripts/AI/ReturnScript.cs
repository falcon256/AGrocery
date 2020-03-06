using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnScript : MonoBehaviour
{
    //public Transform home;

    Vector3 startPos;

    public Animator playerAnims;

    public int walkSpeed = 5;
    public int runSpeed = 20;
    public int jumpHeight = 1;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        Return();
    }

    void Return()
    {
        walkSpeed = 5;
        runSpeed = 20;

        transform.position = Vector3.MoveTowards(transform.position,
        startPos, Time.deltaTime * runSpeed);
        /*Vector3 rotateTowardPlayer = new Vector3(player.transform.position.x,
        transform.position.y, player.transform.position.z);
        transform.LookAt(rotateTowardPlayer);*/

        playerAnims.SetBool("isRunningForward", true);
        if(this.transform.position == startPos)
        {
            playerAnims.SetBool("isRunningForward", false);
        }
    }
}
