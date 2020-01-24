using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScannerColliderScriptVR : MonoBehaviour
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
            PlayerMoneyHandler.PlayerMoney = 100.00m;
        }
        if (PlayerMoneyHandler.TotalCost <= 0.00m)
        {
            PlayerMoneyHandler.TotalCost = 0.00m;
        }
    }
void OnTriggerExit(Collider product)
{

        if (product.gameObject.tag == "Product1")
        {
                PlayerMoneyHandler.TotalCost = PlayerMoneyHandler.TotalCost + PlayerMoneyHandler.Product1Cost;

                PlayerMoneyHandler.Product1Count = PlayerMoneyHandler.Product1Count + 1;

                totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;

                totalMoneyCheckoutText = totalMoneyCheckoutTextBox.GetComponent<Text>();
                totalMoneyCheckoutText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;

                product1CountText = product1CountTextBox.GetComponent<Text>();
                product1CountText.text = "Product 1: " + PlayerMoneyHandler.Product1Count;
                holdingProduct1 = false;
        }

        if (product.gameObject.tag == "Product2")
        {
                PlayerMoneyHandler.TotalCost = PlayerMoneyHandler.TotalCost + PlayerMoneyHandler.Product2Cost;

                PlayerMoneyHandler.Product2Count = PlayerMoneyHandler.Product2Count + 1;

                totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;

                totalMoneyCheckoutText = totalMoneyCheckoutTextBox.GetComponent<Text>();
                totalMoneyCheckoutText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;

                product2CountText = product2CountTextBox.GetComponent<Text>();
                product2CountText.text = "Product 2: " + PlayerMoneyHandler.Product2Count;
                holdingProduct2 = false;            
        }

        if (product.gameObject.tag == "Product3")
        {
                PlayerMoneyHandler.TotalCost = PlayerMoneyHandler.TotalCost + PlayerMoneyHandler.Product3Cost;

                PlayerMoneyHandler.Product3Count = PlayerMoneyHandler.Product3Count + 1;

                totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;

                totalMoneyCheckoutText = totalMoneyCheckoutTextBox.GetComponent<Text>();
                totalMoneyCheckoutText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;

                product3CountText = product3CountTextBox.GetComponent<Text>();
                product3CountText.text = "Product 3: " + PlayerMoneyHandler.Product3Count;
                holdingProduct3 = false;
        }

        if (atCheckoutCounter && Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerMoneyHandler.TotalCost == PlayerMoneyHandler.CurrentOffer)
            {
                PlayerMoneyHandler.PlayerMoney = PlayerMoneyHandler.PlayerMoney - PlayerMoneyHandler.TotalCost;
                PlayerMoneyHandler.TotalCost = PlayerMoneyHandler.TotalCost - PlayerMoneyHandler.TotalCost;
                PlayerMoneyHandler.CurrentOffer = 0.00m;
                PlayerMoneyHandler.Product1Count = 0;
                PlayerMoneyHandler.Product2Count = 0;
                PlayerMoneyHandler.Product3Count = 0;
                playerMoneyText = playerMoneyTextBox.GetComponent<Text>();
                playerMoneyText.text = "Player Money: " + PlayerMoneyHandler.PlayerMoney;
                playerMoneyCheckoutText = playerMoneyCheckoutTextBox.GetComponent<Text>();
                playerMoneyCheckoutText.text = "Player Money: " + PlayerMoneyHandler.PlayerMoney;
                totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;
                totalMoneyCheckoutText = totalMoneyCheckoutTextBox.GetComponent<Text>();
                totalMoneyCheckoutText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;
                currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<Text>();
                currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer;
                product1CountText = product1CountTextBox.GetComponent<Text>();
                product1CountText.text = "Product 1: " + PlayerMoneyHandler.Product1Count;
                product2CountText = product2CountTextBox.GetComponent<Text>();
                product2CountText.text = "Product 2: " + PlayerMoneyHandler.Product2Count;
                product3CountText = product3CountTextBox.GetComponent<Text>();
                product3CountText.text = "Product 3: " + PlayerMoneyHandler.Product3Count;
                notificationText = notificationTextBox.GetComponent<Text>();
                notificationText.text = "That's the exact amount! Have a nice Day!";
            }
            else if (PlayerMoneyHandler.CurrentOffer > PlayerMoneyHandler.TotalCost)
            {
                PlayerMoneyHandler.PlayerMoney = PlayerMoneyHandler.PlayerMoney - PlayerMoneyHandler.TotalCost;
                PlayerMoneyHandler.Change = PlayerMoneyHandler.CurrentOffer - PlayerMoneyHandler.TotalCost;
                PlayerMoneyHandler.TotalCost = PlayerMoneyHandler.TotalCost - PlayerMoneyHandler.TotalCost;
                PlayerMoneyHandler.CurrentOffer = 0.00m;
                PlayerMoneyHandler.Product1Count = 0;
                PlayerMoneyHandler.Product2Count = 0;
                PlayerMoneyHandler.Product3Count = 0;
                playerMoneyText = playerMoneyTextBox.GetComponent<Text>();
                playerMoneyText.text = "Player Money: " + PlayerMoneyHandler.PlayerMoney;
                playerMoneyCheckoutText = playerMoneyCheckoutTextBox.GetComponent<Text>();
                playerMoneyCheckoutText.text = "Player Money: " + PlayerMoneyHandler.PlayerMoney;
                totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;
                totalMoneyCheckoutText = totalMoneyCheckoutTextBox.GetComponent<Text>();
                totalMoneyCheckoutText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;
                currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<Text>();
                currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer;
                product1CountText = product1CountTextBox.GetComponent<Text>();
                product1CountText.text = "Product 1: " + PlayerMoneyHandler.Product1Count;
                product2CountText = product2CountTextBox.GetComponent<Text>();
                product2CountText.text = "Product 2: " + PlayerMoneyHandler.Product2Count;
                product3CountText = product3CountTextBox.GetComponent<Text>();
                product3CountText.text = "Product 3: " + PlayerMoneyHandler.Product3Count;
                notificationText = notificationTextBox.GetComponent<Text>();
                notificationText.text = "Here's your change! You get " + PlayerMoneyHandler.Change + " back. Have a nice Day!";

                while (PlayerMoneyHandler.TotalCost > 0)
                {
                    /*(if PlayerMoneyHandler.TotalCost > 100)
                    {
                    instantiate(hundredDollarBillPrefab);
                    }
                */

                }
                //For instatiating change use a while loop. While TotalCost > 0, Instantiate Money with denominations adding to the change amount.
            }
            else if (PlayerMoneyHandler.TotalCost > PlayerMoneyHandler.CurrentOffer)
            {
                notificationText = notificationTextBox.GetComponent<Text>();
                notificationText.text = "You don't have enough money! GIVE ME MORE CASH OR PUT SOMETHING BACK!";
            }
        }
    }
    }
