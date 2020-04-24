using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControlVR : MonoBehaviour
{
    public GameObject player;

    public GameObject employee;

    public GameObject askForHelpMenuCanvas;

    public GameObject difficultyMenuCanvas;

    public GameObject eventSystem;

    public GameObject beveragesButton;

    public GameObject easyButton;

    //public GameObject moneyCanvas;
    //public GameObject checkoutCounterCam;

    //public bool checkoutCounterCanvasHidden = false;
    //public bool checkoutCounterCanvasShowing = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        employee = GameObject.FindWithTag("Employee");

        //askForHelpMenuCanvas = GameObject.FindWithTag("AskMenuCanvas");

        eventSystem = GameObject.FindWithTag("EventSystem");

        //beveragesButton = GameObject.FindWithTag("BeveragesButton");

        //easyButton = GameObject.FindWithTag("EasyButton");

        //moneyCanvas = GameObject.FindWithTag("MoneyCanvas");

        //checkoutCounterCanvasHidden = true;
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Oculus_CrossPlatform_Button3"))
        //{
        //    eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(beveragesButton);
        //}

        //if (checkoutCounterCanvasHidden)
        //{
        //    moneyCanvas.GetComponent<Canvas>().enabled = false;

        //}
        //if (checkoutCounterCanvasShowing)
        //{
        //    moneyCanvas.GetComponent<Canvas>().enabled = true;
        //}
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Employee")
        {
            askForHelpMenuCanvas.SetActive(true);
            askForHelpMenuCanvas.GetComponent<Canvas>().enabled = true;
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(beveragesButton);
        }

        if (player.gameObject.tag == "ShoppingList" && difficultyMenuCanvas != null)
        {
            difficultyMenuCanvas.SetActive(true);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(easyButton);
        }

        //if (player.gameObject.tag == "CheckoutCounter")
        //{
        //    if (checkoutCounterCanvasHidden)
        //    {
        //        checkoutCounterCanvasShowing = true;
        //        checkoutCounterCanvasHidden = false;
        //    }
        //}
    }

    //void OnTriggerStay(Collider player)
    //{
    //    if (player.gameObject.tag == "Employee")
    //    {
    //        askForHelpMenuCanvas.GetComponent<Canvas>().enabled = false;
    //    }
    //}

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Employee")
        {
            askForHelpMenuCanvas.SetActive(false);
        }

        //if (player.gameObject.tag == "CheckoutCounter")
        //{
        //    if (checkoutCounterCanvasShowing)
        //    {
        //        checkoutCounterCanvasShowing = false;
        //        checkoutCounterCanvasHidden = true;
        //    }
        //}
    }
}