using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class ScannerColliderScriptVRV2 : MonoBehaviour
{
  public DifficultyChooseVR difficultyChooseVR;

  public ProductData productData;

  public GameObject player;
  public Transform playerHand;
  public GameObject product;
  public GameObject[] products;

  public GameObject currentProduct;

  public int timeSinceScanned;
  public float currentProductPrice;

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

    public GameObject shoppingListTextObject;
    public TextMeshProUGUI shoppingListText;

    public StringBuilder listText;

    public bool scanningProduct = false;

 // public TextMeshProUGUI outputTotalText;

  public StringBuilder outputTotalText;
  public StringBuilder itemizedText;
  public StringBuilder selfCheckoutMainText;
  public PayScreen payScreen;
  public float productTotal = 0;
  public float productCost;
  public string productName;

  float scanTime = .5f;
  float scanTimer = 0;
  bool scannable = true;
  
  public float total;
  public float newTotal;

  public int numItemsScanned = 0;

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
    product = GameObject.FindGameObjectWithTag("Product");
    products = GameObject.FindGameObjectsWithTag("Product");

    shoppingListTextObject = GameObject.FindWithTag("shoppingListText");
        if (shoppingListTextObject != null)
        {
            shoppingListText = shoppingListTextObject.GetComponent<TMPro.TextMeshProUGUI>();
        }

    itemizedText = new StringBuilder();
    outputTotalText = new StringBuilder();
    selfCheckoutMainText = new StringBuilder();
    listText = new StringBuilder();


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
     
    if(scanTimer > scanTime)
    {
      scannable = true;
    }
    

  }
  void OnTriggerExit(Collider collidedProduct)
  {
    if (!scannable)
    {
      return;
    }
        if (collidedProduct.gameObject.tag == "Product")
        {
            if (collidedProduct.GetComponent<ProductData>().hasBeenScanned == false)
            {
                payScreen = GetComponentInParent<PayScreen>();

                scanningProduct = true;
                collidedProduct.GetComponent<ProductData>().hasBeenScanned = true;

                productData = collidedProduct.GetComponent<ProductData>();
                productCost = productData.price;
                productName = collidedProduct.name.Replace("(Clone)", " ");

                itemizedText.Append($"{productName} {productCost.ToString("c")} \n");
                payScreen.itemizedText.text = itemizedText.ToString();

                newTotal = total + productCost;

                outputTotalText.Clear();
                outputTotalText.Append(newTotal.ToString("c"));
                payScreen.outputTotalText.text = outputTotalText.ToString();


                scannable = false;
                scanTimer = 0;
                total += productCost;

                numItemsScanned = numItemsScanned + 1;
            }

            //if(collidedProduct == difficultyChooseVR.GetComponent<DifficultyChooseVR>().currentProduct && shoppingListText != null && shoppingListTextObject != null)
            //{
            //    listText.Remove(currentProduct.name.Length, currentProduct.name.Length);
            //    shoppingListText.text = listText.ToString();
            //}

        }
  }

  void OnTriggerStay(Collider collidedProduct)
  {

    if (collidedProduct.gameObject.tag == "Product")
    {
      scanningProduct = false;
      timeSinceScanned++;
    }
  }

  /*

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
              playerMoneyText = playerMoneyTextBox.GetComponent<TextMeshProUGUI>();
              playerMoneyText.TextMeshProUGUI = "Player Money: " + PlayerMoneyHandler.PlayerMoney;
              playerMoneyCheckoutText = playerMoneyCheckoutTextBox.GetComponent<TextMeshProUGUI>();
              playerMoneyCheckoutText.TextMeshProUGUI = "Player Money: " + PlayerMoneyHandler.PlayerMoney;
              totalMoneyText = totalMoneyTextBox.GetComponent<TextMeshProUGUI>();
              totalMoneyText.TextMeshProUGUI = "Total Cost: " + PlayerMoneyHandler.TotalCost;
              totalMoneyCheckoutText = totalMoneyCheckoutTextBox.GetComponent<TextMeshProUGUI>();
              totalMoneyCheckoutText.TextMeshProUGUI = "Total Cost: " + PlayerMoneyHandler.TotalCost;
              currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
              currentOfferCheckoutText.TextMeshProUGUI = "Current Offer: " + PlayerMoneyHandler.CurrentOffer;
              product1CountText = product1CountTextBox.GetComponent<TextMeshProUGUI>();
              product1CountText.TextMeshProUGUI = "Product 1: " + PlayerMoneyHandler.Product1Count;
              product2CountText = product2CountTextBox.GetComponent<TextMeshProUGUI>();
              product2CountText.TextMeshProUGUI = "Product 2: " + PlayerMoneyHandler.Product2Count;
              product3CountText = product3CountTextBox.GetComponent<TextMeshProUGUI>();
              product3CountText.TextMeshProUGUI = "Product 3: " + PlayerMoneyHandler.Product3Count;
              notificationText = notificationTextBox.GetComponent<TextMeshProUGUI>();
              notificationText.TextMeshProUGUI = "That's the exact amount! Have a nice Day!";
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
              playerMoneyText = playerMoneyTextBox.GetComponent<TextMeshProUGUI>();
              playerMoneyText.TextMeshProUGUI = "Player Money: " + PlayerMoneyHandler.PlayerMoney;
              playerMoneyCheckoutText = playerMoneyCheckoutTextBox.GetComponent<TextMeshProUGUI>();
              playerMoneyCheckoutText.TextMeshProUGUI = "Player Money: " + PlayerMoneyHandler.PlayerMoney;
              totalMoneyText = totalMoneyTextBox.GetComponent<TextMeshProUGUI>();
              totalMoneyText.TextMeshProUGUI = "Total Cost: " + PlayerMoneyHandler.TotalCost;
              totalMoneyCheckoutText = totalMoneyCheckoutTextBox.GetComponent<TextMeshProUGUI>();
              totalMoneyCheckoutText.TextMeshProUGUI = "Total Cost: " + PlayerMoneyHandler.TotalCost;
              currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
              currentOfferCheckoutText.TextMeshProUGUI = "Current Offer: " + PlayerMoneyHandler.CurrentOffer;
              product1CountText = product1CountTextBox.GetComponent<TextMeshProUGUI>();
              product1CountText.TextMeshProUGUI = "Product 1: " + PlayerMoneyHandler.Product1Count;
              product2CountText = product2CountTextBox.GetComponent<TextMeshProUGUI>();
              product2CountText.TextMeshProUGUI = "Product 2: " + PlayerMoneyHandler.Product2Count;
              product3CountText = product3CountTextBox.GetComponent<TextMeshProUGUI>();
              product3CountText.TextMeshProUGUI = "Product 3: " + PlayerMoneyHandler.Product3Count;
              notificationText = notificationTextBox.GetComponent<TextMeshProUGUI>();
              notificationText.TextMeshProUGUI = "Here's your change! You get " + PlayerMoneyHandler.Change + " back. Have a nice Day!";

              while (PlayerMoneyHandler.TotalCost > 0)
              {
                  (if PlayerMoneyHandler.TotalCost > 100)
                  {
                  instantiate(hundredDollarBillPrefab);
                  }


              }
              //For instatiating change use a while loop. While TotalCost > 0, Instantiate Money with denominations adding to the change amount.
          }
          else if (PlayerMoneyHandler.TotalCost > PlayerMoneyHandler.CurrentOffer)
          {
              notificationText = notificationTextBox.GetComponent<TextMeshProUGUI>();
              notificationText.TextMeshProUGUI = "You don't have enough money! GIVE ME MORE CASH OR PUT SOMETHING BACK!";
          }*/
}
