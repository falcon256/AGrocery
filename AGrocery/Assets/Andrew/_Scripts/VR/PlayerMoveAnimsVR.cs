using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnimsVR : MonoBehaviour
{
    public GameObject player;

    public Animator playerAnims;
    public int walkSpeed = 5;
    public int runSpeed = 20;
    public int jumpHeight = 5;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //These are the controls for the player. They use the default Unity inputs along with ints I have set up for different speeds

        var forwardbackward = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * Time.deltaTime * walkSpeed;
        var updown = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") * Time.deltaTime * jumpHeight;
        var leftright = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal") * Time.deltaTime * walkSpeed;

        transform.Translate(0, 0 , forwardbackward);
        transform.Translate(0, updown, 0);
        transform.Translate(leftright, 0, 0);

        //These are animation booleans which are activated when the player is or is not pressing a button. They are connected to a animation controller called PlayerAnims

        if (Input.GetButtonDown("Oculus_CrossPlatform_Button1"))
        {
            playerAnims.SetBool("isJumping", true);
        }
        else
        {
            playerAnims.SetBool("isJumping", false);
        }
        if (Input.GetKey(KeyCode.E))
        {
            playerAnims.SetBool("isGrabbing", true);
        }
        else
        {
            playerAnims.SetBool("isGrabbing", false);
        }
    }
}
