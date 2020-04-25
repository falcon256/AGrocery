using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;

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
  private ChangeCalculator changeCalculator;

  
  private GameObject change;

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

  decimal total;
  decimal newTotal;
  
  

  float currentOffer;
  decimal changeAmount;

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
    changeCalculator = new ChangeCalculator();
   
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

  IEnumerator PaymentReceived()
  {
    yield return new WaitForSeconds(5f);
 
    payScreenScript.mainText.text = ("Thank You! \n Have a nice day!");
    payScreenScript.itemizedText.text = String.Empty;
    payScreenScript.audioSource2.PlayOneShot(payScreenScript.clip6);
  
    StartCoroutine("ReturnToMain");
   
  }

  IEnumerator ReturnToMain()
  {
    yield return new WaitForSeconds(payScreenScript.clip6.length + 2f);
   
    payScreenScript.Reset();
  }

  IEnumerator DestroyMoney()
  {
    yield return new WaitForSeconds(.02f);

    thisObject.SetActive(false);
  }
  void OnTriggerEnter(Collider collidedMoney)
  {

    if (collidedMoney.gameObject.tag == "Money")
    {

      if (payScreenScript.isCash)
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
            

            itemizedText = scanner.GetComponent<ScannerColliderScriptVRV2>().itemizedText;
            selfCheckoutMainText = scanner.GetComponent<ScannerColliderScriptVRV2>().selfCheckoutMainText;
            outputTotalText = scanner.GetComponent<ScannerColliderScriptVRV2>().outputTotalText;

            usingCash = true;
            collidedMoney.GetComponent<MoneyData>().hasBeenUsed = true;

            moneyData = collidedMoney.GetComponent<MoneyData>();
            moneyValue = moneyData.value;
            var moneyValueConverted = Convert.ToDecimal(moneyValue);
            currencyType = collidedMoney.name.Replace("(Clone)", " ");

            newTotal = Decimal.Subtract(total , moneyValueConverted);
            scanner.GetComponent<ScannerColliderScriptVRV2>().total = newTotal;
            itemizedText.Append($"\n -{moneyValue:c}");
            payScreenScript.itemizedText.text = itemizedText.ToString();
            outputTotalText.Clear();
            outputTotalText.Append(newTotal.ToString("c"));
            payScreenScript.outputTotalText.text = outputTotalText.ToString();
           


            currentOffer = currentOffer + moneyValue;
            selfCheckoutMainText.Clear();
            selfCheckoutMainText.Append($"{currencyType} {moneyValue.ToString("c")} {"Current Offer:" + currentOffer.ToString("c")} \n");
            payScreenScript.mainText.text = selfCheckoutMainText.ToString();

            PlayerMoneyHandler.PlayerMoney = PlayerMoneyHandler.PlayerMoney - moneyValue;
           

          
            StartCoroutine("DestroyMoney");
            scannable = false;
            scanTimer = 0;


            


           
          }
          if (Convert.ToDecimal(currentOffer) >= payScreenScript.originalTotal && scanner.GetComponent<ScannerColliderScriptVRV2>().numItemsScanned > 0)
          {

            costReached = true;
            changeAmount = Convert.ToDecimal(moneyValue) - total;
            payScreenScript.outputTotalText.text = $"{0:c}";
            payScreenScript.changeText.text = "CHANGE: " + $"{changeAmount:c}";
           
            var expectedChange = changeCalculator.MakeChange(changeAmount);
            

            foreach (var amt in expectedChange)
            {
              float zPos = UnityEngine.Random.Range(changeSpawner.transform.position.z - .03f, changeSpawner.transform.position.z - .06f);
              float yPos = UnityEngine.Random.Range(changeSpawner.transform.position.y + .001f, changeSpawner.transform.position.y + .022f);
              Vector3 changePos = new Vector3(changeSpawner.transform.position.x, yPos, zPos);
              switch (amt)
              {
                case 50:
                  Instantiate(fiftyDollar, changePos, Quaternion.identity);
                  break;
                case 20:
                  Instantiate(twentyDollar, changePos, Quaternion.identity);
                  break;
                case 10:
                  Instantiate(tenDollar, changePos, Quaternion.identity);
                  break;
                case 5:
                  Instantiate(fiveDollar, changePos, Quaternion.identity);
                  break;
                case 1:
                  Instantiate(oneDollar, changePos, Quaternion.identity);
                  break;
                case .25m:
                  Instantiate(quarter, changePos, Quaternion.identity);
                  break;
                case .10m:
                  Instantiate(dime, changePos, Quaternion.identity);
                  break;
                case .05m:
                  Instantiate(nickel, changePos, Quaternion.identity);
                  break;
                case .01m:
                  Instantiate(penny, changePos, Quaternion.identity);
                  break;
                default:
                  break;
              }
            }
              StartCoroutine("PaymentReceived");
          }

        
         
        }
    
      
     
      }
    }
  }
}
