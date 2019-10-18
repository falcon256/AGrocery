using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnims : MonoBehaviour
{
    public Animator playerAnims;
    public int walkSpeed = 5;
    public int runSpeed = 20;
    public int jumpHeight = 1;

    void Start()
    {
        
    }

    void Update()
    {

        //These are the controls for the player. They use the default Unity inputs along with ints I have set up for different speeds

        var rotate = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var walkForward = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed;
        var runForward = Input.GetAxis("Vertical") * Time.deltaTime * runSpeed;
        var jump = Input.GetAxis("Jump") * Time.deltaTime * jumpHeight;

        transform.Translate(walkForward, 0, 0);
        transform.Rotate(0, rotate, 0);
        transform.Translate(0, jump, 0);

        //These are animation booleans which are activated when the player is or is not pressing a button. They are connected to a animation controller called PlayerAnims

        if (Input.GetKey(KeyCode.W))
        {
            playerAnims.SetBool("isWalkingForward", true);
        }
        else
        {
            playerAnims.SetBool("isWalkingForward", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerAnims.SetBool("isWalkingBackward", true);
        }
        else
        {
            playerAnims.SetBool("isWalkingBackward", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnims.SetBool("isRunningForward", true);
            transform.Translate(runForward, 0, 0);
        }
        else
        {
            playerAnims.SetBool("isRunningForward", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnims.SetBool("isJumping", true);
        }
        else
        {
            playerAnims.SetBool("isJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnims.SetBool("isGrabbing", true);
        }
        else
        {
            playerAnims.SetBool("isGrabbing", false);
        }
    }
}
