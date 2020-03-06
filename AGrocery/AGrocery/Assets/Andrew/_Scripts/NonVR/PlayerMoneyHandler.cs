using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyHandler : MonoBehaviour
{
    public GameObject product1;
    public GameObject[] products1;
    public GameObject product2;
    public GameObject[] products2;
    public GameObject product3;
    public GameObject[] products3;

    public static decimal PlayerMoney = 100m;

    public static decimal TotalCost = 0.00m;

    public static decimal CurrentOffer = 0.00m;

    public static decimal Change = 0.00m;

    public static decimal Penny = 0.01m;

    public static decimal Nickel = 0.05m;

    public static decimal Dime = 0.10m;

    public static decimal Quarter = 0.25m;

    public static decimal OneDollar = 1.00m;

    public static decimal FiveDollars = 5.00m;

    public static decimal TenDollars = 10.00m;

    public static decimal TwentyDollars = 20.00m;

    public static decimal Product1Cost = 1.00m;

    public static decimal Product2Cost = 1.50m;

    public static decimal Product3Cost = 2.00m;

    public static int Product1Count = 0;
    public static int Product2Count = 0;
    public static int Product3Count = 0;

    public GameObject playerMoneyTextBox;
    public Text playerMoneyText;

    public static GameObject product1CountTextBox;
    public static Text product1CountText;

    public static GameObject product2CountTextBox;
    public static Text product2CountText;

    public static GameObject product3CountTextBox;
    public static Text product3CountText;

    public bool closeToProduct1 = false;
    public bool closeToProduct2 = false;
    public bool closeToProduct3 = false;
    public bool notHolding = false;
    public bool holdingProduct1 = false;
    public bool holdingProduct2 = false;
    public bool holdingProduct3 = false;

    public bool atCheckoutCounter = false;

    // Start is called before the first frame update
    void Start()
    {
        //products1 = GameObject.FindGameObjectsWithTag("Product1");
        //products2 = GameObject.FindGameObjectsWithTag("Product2");
        //products3 = GameObject.FindGameObjectsWithTag("Product3");

        playerMoneyTextBox = GameObject.FindWithTag("PlayerMoneyText");
        product1CountTextBox = GameObject.FindWithTag("Product1CountText");
        product2CountTextBox = GameObject.FindWithTag("Product2CountText");
        product3CountTextBox = GameObject.FindWithTag("Product3CountText");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMoney <= 0)
        {
            PlayerMoney = 0;
            Debug.Log("You spent all of your money!");
        }
    }
}