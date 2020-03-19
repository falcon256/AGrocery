using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuCameraControlVR : MonoBehaviour
{
    public GameObject player;

    public GameObject askForHelpMenuCanvas;

    public bool checkoutCounterCanvasHidden = false;
    public bool checkoutCounterCanvasShowing = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        askForHelpMenuCanvas = GameObject.FindWithTag("AskMenuCanvas");

        checkoutCounterCanvasHidden = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (checkoutCounterCanvasHidden)
        {
            askForHelpMenuCanvas.GetComponent<Canvas>().enabled = false;

        }
        if (checkoutCounterCanvasShowing)
        {
            askForHelpMenuCanvas.GetComponent<Canvas>().enabled = true;
        }
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Employee")
        {
            if (checkoutCounterCanvasHidden)
            {
                checkoutCounterCanvasShowing = true;
                checkoutCounterCanvasHidden = false;
            }
        }
    }
    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Employee")
        {
            if (checkoutCounterCanvasShowing)
            {
                checkoutCounterCanvasShowing = false;
                checkoutCounterCanvasHidden = true;
            }
        }
    }
}