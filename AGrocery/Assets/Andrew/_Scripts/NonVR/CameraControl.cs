using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    public GameObject mainCam;
    public GameObject checkoutCounterCam;

    public bool mainCamMode = false;
    public bool checkoutCounterCamMode = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        mainCamMode = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (mainCamMode)
        {
            mainCam.GetComponent<Camera>().enabled = true;
            mainCam.GetComponent<AudioListener>().enabled = true;
            checkoutCounterCam.GetComponent<Camera>().enabled = false;
            checkoutCounterCam.GetComponent<AudioListener>().enabled = false;

        }
        if (checkoutCounterCamMode)
        {
            mainCam.GetComponent<Camera>().enabled = false;
            mainCam.GetComponent<AudioListener>().enabled = false;
            checkoutCounterCam.GetComponent<Camera>().enabled = true;
            checkoutCounterCam.GetComponent<AudioListener>().enabled = true;
        }




                    if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainCamMode = true;
            checkoutCounterCamMode = false;
            mainCam.GetComponent<Camera>().enabled = true;
            mainCam.GetComponent<AudioListener>().enabled = true;
            checkoutCounterCam.GetComponent<Camera>().enabled = false;
            checkoutCounterCam.GetComponent<AudioListener>().enabled = false;
        }
        }
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "CheckoutCounter")
        {
            if (mainCamMode)
        { 
                mainCamMode = false;
            checkoutCounterCamMode = true;
        }
        }
    }
    void OnTriggerExit(Collider player)
        {
        if (player.gameObject.tag == "CheckoutCounter")
        {
            if (checkoutCounterCamMode)
            {
                mainCamMode = true;
                checkoutCounterCamMode = false;
            }
        }
        }
    }