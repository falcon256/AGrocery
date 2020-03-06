using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColliderScriptVR : MonoBehaviour
{
    public GameObject player;
    public Transform playerHand;
    //public GameObject product;

    public GameObject playerMoneyTextBox;
    public Text playerMoneyText;

    public GameObject playerMoneyCheckoutTextBox;
    public Text playerMoneyCheckoutText;

    public GameObject currentOfferCheckoutTextBox;
    public Text currentOfferCheckoutText;

    public GameObject totalMoneyTextBox;
    public Text totalMoneyText;

    public GameObject totalMoneyCheckoutTextBox;
    public Text totalMoneyCheckoutText;

    public GameObject notificationTextBox;
    public Text notificationText;

    public static GameObject product1CountTextBox;
    public static Text product1CountText;

    public static GameObject product2CountTextBox;
    public static Text product2CountText;

    public static GameObject product3CountTextBox;
    public static Text product3CountText;

    public bool holdingProduct1 = false;
    public bool holdingProduct2 = false;
    public bool holdingProduct3 = false;
    public bool atCheckoutCounter = false;
    public bool closeToCart = false;
    public bool holdingCart = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHand = GameObject.FindWithTag("PlayerGrabLocation").transform;
        playerMoneyTextBox = GameObject.FindWithTag("PlayerMoneyText");
        playerMoneyCheckoutTextBox = GameObject.FindWithTag("PlayerMoneyCheckoutText");
        totalMoneyTextBox = GameObject.FindWithTag("TotalMoneyText");
        totalMoneyCheckoutTextBox = GameObject.FindWithTag("TotalMoneyCheckoutText");
        currentOfferCheckoutTextBox = GameObject.FindWithTag("CurrentOfferCheckoutText");
        notificationTextBox = GameObject.FindWithTag("NotificationText");
        product1CountTextBox = GameObject.FindWithTag("Product1CountText");
        product2CountTextBox = GameObject.FindWithTag("Product2CountText");
        product3CountTextBox = GameObject.FindWithTag("Product3CountText");
        //product = GameObject.FindWithTag("Product");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMoneyHandler.PlayerMoney >= 100)
        {
            PlayerMoneyHandler.PlayerMoney = 100.00f;
        }
        if (PlayerMoneyHandler.TotalCost <= 0.00f)
        {
            PlayerMoneyHandler.TotalCost = 0.00f;
        }
    }
    private void OnTriggerEnter(Collider product)
    {
        if (product.gameObject.tag == "CheckoutCounter")
        {
            atCheckoutCounter = true;
        }
    }

    void OnTriggerExit(Collider product)
    {
        if (product.gameObject.tag == "CheckoutCounter")
        {
            atCheckoutCounter = false;
        }
    }
    }
