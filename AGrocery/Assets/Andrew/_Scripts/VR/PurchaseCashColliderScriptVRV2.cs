using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class PurchaseCashColliderScriptVRV2 : MonoBehaviour
{
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

    }
    void OnTriggerExit(Collider collidedMoney)
    {
        
        if (collidedMoney.gameObject.tag == "Money")
        {  
            if(!costReached)
            {
            payScreen = GetComponentInParent<PayScreen>();
            scanner.GetComponent<ScannerColliderScriptVRV2>();

            total = scanner.GetComponent<ScannerColliderScriptVRV2>().total;
            newTotal = scanner.GetComponent<ScannerColliderScriptVRV2>().newTotal;

            selfCheckoutMainText = scanner.GetComponent<ScannerColliderScriptVRV2>().selfCheckoutMainText;
            outputTotalText = scanner.GetComponent<ScannerColliderScriptVRV2>().outputTotalText;

            usingCash = true;

            moneyData = collidedMoney.GetComponent<MoneyData>();
            moneyValue = moneyData.value;
            currencyType = collidedMoney.name.Replace("(Clone)", " ");

            selfCheckoutMainText.Append($"{currencyType} {moneyValue.ToString("c")} \n");
            payScreen.mainText.text = selfCheckoutMainText.ToString();

            newTotal = total - moneyValue;

            outputTotalText.Clear();
            outputTotalText.Append(newTotal.ToString("c"));
            payScreen.outputTotalText.text = outputTotalText.ToString();


            scannable = false;
            scanTimer = 0;
            total -= moneyValue;

            if(moneyValue > total)
            {
                costReached = true;
                payScreen.outputTotalText.text = "Your Change is " + outputTotalText.ToString();
            }
            }            
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
