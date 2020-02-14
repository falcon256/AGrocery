using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseCashColliderScriptVR : MonoBehaviour
{
    public MoneyData moneyData;

    public GameObject player;
    public Transform playerHand;

    public GameObject money;
    public GameObject[] allMoney;

    public GameObject currentMoney;


    public int timeSinceScanned;
    public float currentMoneyValue;

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

    public static GameObject currentOfferTextBox;
    public static Text currentOfferText;

    public bool usingCash = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHand = GameObject.FindWithTag("PlayerGrabLocation").transform;
        playerMoneyTextBox = GameObject.FindWithTag("PlayerMoneyText");
        playerMoneyCheckoutTextBox = GameObject.FindWithTag("PlayerMoneyCheckoutText");
        totalMoneyTextBox = GameObject.FindWithTag("TotalMoneyText");
        totalMoneyCheckoutTextBox = GameObject.FindWithTag("TotalMoneyCheckoutText");
        currentOfferTextBox = GameObject.FindWithTag("CurrentOfferText");
        currentOfferCheckoutTextBox = GameObject.FindWithTag("CurrentOfferCheckoutText");
        notificationTextBox = GameObject.FindWithTag("NotificationText");
        product1CountTextBox = GameObject.FindWithTag("Product1CountText");
        money = GameObject.FindWithTag("Money");
        allMoney = GameObject.FindGameObjectsWithTag("Money");

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

        if (usingCash && timeSinceScanned > 5)
        {
            PlayerMoneyHandler.PlayerMoney = PlayerMoneyHandler.PlayerMoney - currentMoneyValue;

            PlayerMoneyHandler.TotalCost = PlayerMoneyHandler.TotalCost - currentMoneyValue;

            PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer + currentMoneyValue;

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

            currentOfferText = currentOfferTextBox.GetComponent<Text>();
            currentOfferText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer;

            timeSinceScanned = 0;

            Destroy(currentMoney);

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.scanObjectBeep);
        }
    }
    void OnTriggerExit(Collider collidedMoney)
    {
        
        if (collidedMoney.gameObject.tag == "Money")
        {
            usingCash = true;
            currentMoney = collidedMoney.gameObject;
            moneyData = currentMoney.GetComponent<MoneyData>();
            currentMoneyValue = moneyData.value;
        }
    }

    void OnTriggerStay(Collider collidedMoney)
    {

        if (collidedMoney.gameObject.tag == "Money")
        {
            usingCash = false;
            timeSinceScanned++;
        }
    }
}
