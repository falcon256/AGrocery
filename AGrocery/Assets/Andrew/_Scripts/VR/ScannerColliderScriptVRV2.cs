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
}
