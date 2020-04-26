using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class PurchaseCashColliderScriptVRV2 : MonoBehaviour
{
    public GameObject penny;
    public GameObject nickel;
    public GameObject dime;
    public GameObject quarter;
    public GameObject oneDollar;
    public GameObject fiveDollar;
    public GameObject tenDollar;
    public GameObject twentyDollar;
    public GameObject fiftyDollar;
    public GameObject changeSpawner;
    public GameObject moneyZone;

    public MoneyData moneyData;

    public GameObject player;
    public Transform playerHand;

    public GameObject scanner;

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
    public bool costReached = false;
    public bool dispensingChange = false;

    public StringBuilder outputTotalText;
    public StringBuilder itemizedText;
    public StringBuilder selfCheckoutMainText;
    public PayScreen payScreen;
    public float productTotal = 0;
    public float moneyValue;
    public string currencyType;

    float scanTime = .5f;
    float scanTimer = 0;
    bool scannable = true;

    float total;
    float newTotal;

    float currentOffer;

    float changeAmount;
    float changeStartingAmount;
    float changeCount;

    float changeTextAmount;

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

        scanTimer += Time.deltaTime;

        if (scanTimer > scanTime)
        {
            scannable = true;
        }

        if(dispensingChange)
        {
                if (changeAmount > 50)
                {
                    Instantiate(fiftyDollar, changeSpawner.transform.position, Quaternion.identity);
                    changeAmount = changeAmount - 50;
                    changeCount = changeCount + 50;
                    
                }
                if (changeAmount > 20)
                {
                    Instantiate(twentyDollar, changeSpawner.transform.position, Quaternion.identity);
                    changeAmount = changeAmount - 20;
                    changeCount = changeCount + 20;

            }
                if (changeAmount > 10)
                {
                    Instantiate(tenDollar, changeSpawner.transform.position, Quaternion.identity);
                    changeAmount = changeAmount - 10;
                    changeCount = changeCount + 5;
            }
                if (changeAmount > 5)
                {
                    Instantiate(fiveDollar, changeSpawner.transform.position, Quaternion.identity);
                    changeAmount = changeAmount - 5;
                    changeCount = changeCount + 5;
            }
                if (changeAmount > 1)
                {
                    Instantiate(oneDollar, changeSpawner.transform.position, Quaternion.identity);
                    changeAmount = changeAmount - 1;
                    changeCount = changeCount + 1;
            }
                if (changeAmount > 0.25)
                {
                    Instantiate(quarter, changeSpawner.transform.position, Quaternion.identity);
                    changeAmount = changeAmount - 0.25f;
                    changeCount = changeCount + 0.25f;
            }
                if (changeAmount > 0.10)
                {
                    Instantiate(dime, changeSpawner.transform.position, Quaternion.identity);
                    changeAmount = changeAmount - 0.10f;
                    changeCount = changeCount + 0.10f;
            }
                if (changeAmount > 0.05)
                {
                    Instantiate(nickel, changeSpawner.transform.position, Quaternion.identity);
                    changeAmount = changeAmount - 0.05f;
                    changeCount = changeCount + 0.05f;
            }
                if (changeAmount > 0.01)
                {
                    Instantiate(penny, changeSpawner.transform.position, Quaternion.identity);
                    changeAmount = changeAmount - 0.01f;
                    changeCount = changeCount + 0.01f;
            }
            }
        }

    void OnTriggerEnter(Collider collidedMoney)
    {

        if (collidedMoney.gameObject.tag == "Money")
        {
            if (collidedMoney.GetComponent<MoneyData>().hasBeenUsed == false)
            {
                if (!costReached)
                {
                    payScreen = GetComponentInParent<PayScreen>();
                    scanner.GetComponent<ScannerColliderScriptVRV2>();

                    total = scanner.GetComponent<ScannerColliderScriptVRV2>().total;
                    newTotal = scanner.GetComponent<ScannerColliderScriptVRV2>().newTotal;

                    itemizedText = scanner.GetComponent<ScannerColliderScriptVRV2>().itemizedText;
                    selfCheckoutMainText = scanner.GetComponent<ScannerColliderScriptVRV2>().selfCheckoutMainText;
                    outputTotalText = scanner.GetComponent<ScannerColliderScriptVRV2>().outputTotalText;

                    usingCash = true;
                    collidedMoney.GetComponent<MoneyData>().hasBeenUsed = true;

                    moneyData = collidedMoney.GetComponent<MoneyData>();
                    moneyValue = moneyData.value;
                    currencyType = collidedMoney.name.Replace("(Clone)", " ");

                    newTotal = total - moneyValue;

                    currentOffer = currentOffer + moneyValue;                    

                    selfCheckoutMainText.Append($"{currencyType} {moneyValue.ToString("c")} {"Current Offer:" + currentOffer.ToString("c")} \n");
                    payScreen.mainText.text = selfCheckoutMainText.ToString();

                    PlayerMoneyHandler.PlayerMoney = PlayerMoneyHandler.PlayerMoney - moneyValue;

                    //playerMoneyText = playerMoneyTextBox.GetComponent<Text>();
                    //playerMoneyText.text = "Player Money: " + PlayerMoneyHandler.PlayerMoney.ToString("c");

                    //outputTotalText.Clear();
                    //outputTotalText.Append(newTotal.ToString("c"));
                    //payScreen.outputTotalText.text = outputTotalText.ToString();

                    scannable = false;
                    scanTimer = 0;

                    if (currentOffer >= total && scanner.GetComponent<ScannerColliderScriptVRV2>().numItemsScanned > 0)
                    {                       
                        costReached = true;
                        changeTextAmount = currentOffer - total;
                        changeStartingAmount = currentOffer - total;
                        changeAmount = currentOffer - total;
                        outputTotalText.Clear();
                        outputTotalText.Append(changeTextAmount.ToString("c"));
                        payScreen.outputTotalText.text = "Your Change is " + outputTotalText.ToString();

                        if(changeAmount > 0)
                        {
                            dispensingChange = true;
                        }
                        if (changeAmount <= 0 && changeCount == changeStartingAmount)
                        {
                            dispensingChange = false;
                        }

                          }     
                        }
                    }
        }
            }
        }      