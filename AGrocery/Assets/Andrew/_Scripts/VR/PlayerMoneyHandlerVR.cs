using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyHandlerVR : MonoBehaviour
{
    public static float PlayerMoney = 100f;

    public static float TotalCost = 0.00f;

    public static float CurrentOffer = 0.00f;

    public static float Change = 0.00f;

    public static float Penny = 0.01f;

    public static float Nickel = 0.05f;

    public static float Dime = 0.10f;

    public static float Quarter = 0.25f;

    public static float OneDollar = 1.00f;

    public static float FiveDollars = 5.00f;

    public static float TenDollars = 10.00f;

    public static float TwentyDollars = 20.00f;

    public GameObject playerMoneyTextBox;
    public Text playerMoneyText;

    // Start is called before the first frame update
    void Start()
    { 
        playerMoneyTextBox = GameObject.FindWithTag("PlayerMoneyText");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMoney >= 100)
        {
            PlayerMoney = 100.00f;
        }
        if (PlayerMoney <= 0)
        {
            PlayerMoney = 0.00f;
            Debug.Log("You spent all of your money!");
        }
    }
}