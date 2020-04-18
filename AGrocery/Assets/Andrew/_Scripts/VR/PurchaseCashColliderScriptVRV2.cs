using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;

public class PurchaseCashColliderScriptVRV2 : MonoBehaviour
{
  public MoneyData moneyData;
  public GameObject thisObject;
  public GameObject player;
  public Transform playerHand;

  public Transform moneyGrabber;

  public PayScreen payScreenScript;
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
  public float productTotal = 0;
  public float moneyValue;
  public string currencyType;

  float scanTime = .5f;
  float scanTimer = 0;
  bool scannable = true;

  float total;
  float newTotal;

  float currentOffer;
  float change;

  // Start is called before the first frame update
  void Start()
  {
    payScreenScript = GetComponentInParent<PayScreen>();
    //payScreenCanvas = gameObject.GetComponent<Canvas>();
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
  }

  IEnumerator DestroyMoney()
  {
    yield return new WaitForSeconds(3f);

    thisObject.SetActive(false);
  }
  void OnTriggerEnter(Collider collidedMoney)
  {

    if (collidedMoney.gameObject.tag == "Money")
    {

      thisObject = collidedMoney.gameObject;
     
      if (collidedMoney.GetComponent<MoneyData>().hasBeenUsed == false)
      {
       /* var objGrabbable = thisObject.GetComponent<OVRGrabbable>();
        Destroy(objGrabbable);
        thisObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        thisObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        thisObject.transform.position = Vector3.Lerp(thisObject.transform.position, moneyGrabber.position, .02f);
        StartCoroutine("DestroyMoney");*/
        if (!costReached)
        {
          
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

          payScreenScript.outputTotalText.text = $"{total:c}";


          currentOffer = currentOffer + moneyValue;

          selfCheckoutMainText.Append($"{currencyType} {moneyValue.ToString("c")} {"Current Offer:" + currentOffer.ToString("c")} \n");
          payScreenScript.mainText.text = selfCheckoutMainText.ToString();

          PlayerMoneyHandler.PlayerMoney = PlayerMoneyHandler.PlayerMoney - moneyValue;

          //playerMoneyText = playerMoneyTextBox.GetComponent<Text>();
          //playerMoneyText.text = "Player Money: " + PlayerMoneyHandler.PlayerMoney.ToString("c");

          //outputTotalText.Clear();
          //outputTotalText.Append(newTotal.ToString("c"));
          //payScreen.outputTotalText.text = outputTotalText.ToString();

          scannable = false;
          scanTimer = 0;

         

         
         
          //Destroy(currentMoney);
          if (currentOffer >= total && scanner.GetComponent<ScannerColliderScriptVRV2>().numItemsScanned > 0)
          {
           
            costReached = true;
            change = currentOffer - total;
            payScreenScript.outputTotalText.text = $"{0:c}";
            payScreenScript.itemizedText.text = String.Empty;
            //outputTotalText.Clear();
            //outputTotalText.Append(change.ToString("c"));
            payScreenScript.changeText.text = "CHANGE: " + $"{change:c}";
            // payScreen.outputTotalText.text = "Your Change is " + ;
          }
         
        }
      }
    }
  }
}
