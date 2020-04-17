using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class PurchaseCardColliderScriptVRV2 : MonoBehaviour
{
    public MoneyData moneyData;

    public GameObject player;
    public Transform playerHand;

    public GameObject scanner;

    public int timeoutCounter;
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

    public bool usingCard = false;
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

    float currentOffer;

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

    }
    void OnTriggerEnter(Collider collidedMoney)
    {
        if (collidedMoney.gameObject.tag == "CreditCard")
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

                usingCard = true;

                moneyData = collidedMoney.GetComponent<MoneyData>();
                moneyValue = moneyData.value;
                currencyType = collidedMoney.name.Replace("(Clone)", " ");

                newTotal = total - total;

                currentOffer = currentOffer + moneyValue;

                PlayerMoneyHandler.PlayerMoney = PlayerMoneyHandler.PlayerMoney - total;

                //playerMoneyText = playerMoneyTextBox.GetComponent<Text>();
                //playerMoneyText.text = "Player Money: " + PlayerMoneyHandler.PlayerMoney.ToString("c");

                outputTotalText.Clear();
                outputTotalText.Append(newTotal.ToString("c"));
                payScreen.outputTotalText.text = outputTotalText.ToString();

                scannable = false;
                scanTimer = 0;

                if (currentOffer >= total)
                {
                    costReached = true;
                    payScreen.outputTotalText.text = "You paid with card. No change for you." + outputTotalText.ToString();

                    selfCheckoutMainText.Append($"{currencyType} {PlayerMoneyHandler.PlayerMoney.ToString("c")} \n");
                    payScreen.mainText.text = selfCheckoutMainText.ToString();
                }
            }
        }
        }
    }
