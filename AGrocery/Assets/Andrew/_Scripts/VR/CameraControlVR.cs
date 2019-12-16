using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlVR : MonoBehaviour
{
    public GameObject player;

    public GameObject moneyCanvas;
    public GameObject checkoutCounterCam;

    public bool checkoutCounterCanvasHidden = false;
    public bool checkoutCounterCanvasShowing = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        moneyCanvas = GameObject.FindWithTag("MoneyCanvas");

        checkoutCounterCanvasHidden = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (checkoutCounterCanvasHidden)
        {
            moneyCanvas.GetComponent<Canvas>().enabled = false;

        }
        if (checkoutCounterCanvasShowing)
        {
            moneyCanvas.GetComponent<Canvas>().enabled = true;
        }
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "CheckoutCounter")
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
        if (player.gameObject.tag == "CheckoutCounter")
        {
            if (checkoutCounterCanvasShowing)
            {
                checkoutCounterCanvasShowing = false;
                checkoutCounterCanvasHidden = true;
            }
        }
    }
}