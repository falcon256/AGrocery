using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class ScannerColliderScriptVR : MonoBehaviour
{
  public ProductData productData;

  public GameObject player;
  public Transform playerHand;
  public GameObject product;
  public GameObject[] products;

  public GameObject currentProduct;

  public int timeSinceScanned;
  public float currentProductPrice;

  public GameObject playerMoneyTextBox;
  public TextMeshProUGUI playerMoneyText;

  public GameObject playerMoneyCheckoutTextBox;
  public TextMeshProUGUI playerMoneyCheckoutText;

  public GameObject currentOfferCheckoutTextBox;
  public TextMeshProUGUI currentOfferCheckoutText;

  public GameObject totalMoneyTextBox;
  public TextMeshProUGUI totalMoneyText;

  public GameObject totalMoneyCheckoutTextBox;
  public TextMeshProUGUI totalMoneyCheckoutText;

  public GameObject notificationTextBox;
  public TextMeshProUGUI notificationText;

  public static GameObject product1CountTextBox;
  public static TextMeshProUGUI product1CountText;

  public static GameObject product2CountTextBox;
  public static TextMeshProUGUI product2CountText;

  public static GameObject product3CountTextBox;
  public static TextMeshProUGUI product3CountText;

  public bool scanningProduct = false;

 // public TextMeshProUGUI outputTotalText;

  public StringBuilder outputTotalText;
  public StringBuilder itemizedText;
  public PayScreen payScreen;
  public float productTotal = 0;
  public float productCost;
  public string productName;

  float scanTime = .5f;
  float scanTimer = 0;
  bool scannable = true;
  public float total;
  public float newTotal; 

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
    product = GameObject.FindWithTag("Product");
    products = GameObject.FindGameObjectsWithTag("Product");
    itemizedText = new StringBuilder();
    outputTotalText = new StringBuilder();
    
    


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

    if (scanningProduct && timeSinceScanned > 5)
    {
      PlayerMoneyHandler.TotalCost = PlayerMoneyHandler.TotalCost + currentProductPrice;

      PlayerMoneyHandler.Product1Count = PlayerMoneyHandler.Product1Count + 1;

      totalMoneyText = totalMoneyTextBox.GetComponent<TextMeshProUGUI>();
      totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;

      totalMoneyCheckoutText = totalMoneyCheckoutTextBox.GetComponent<TextMeshProUGUI>();
      totalMoneyCheckoutText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;

      product1CountText = product1CountTextBox.GetComponent<TextMeshProUGUI>();
      product1CountText.text = "Products: " + PlayerMoneyHandler.Product1Count;

      timeSinceScanned = 0;

      SoundManager.Instance.PlayOneShot(SoundManager.Instance.scanObjectBeep);
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
      payScreen = GetComponentInParent<PayScreen>();
      
      scanningProduct = true;

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
