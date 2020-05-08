using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Wallet : MonoBehaviour
{

  public GameObject playerMoneyTextBox;
  public Text playerMoneyText;

  public MoneyData moneyData;
  public float moneyValue;



  void Start()
  {
    playerMoneyTextBox = GameObject.FindWithTag("PlayerMoneyText");
  }


  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Money" || other.gameObject.tag =="CreditCard")
    {

      moneyData = other.GetComponent<MoneyData>();
      moneyValue = moneyData.value;
      PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney + Convert.ToDecimal(moneyValue);
      other.gameObject.SetActive(false);
      Destroy(other.GetComponent<OVRGrabbable>());
      
    }
  }


  // Update is called once per frame
  void Update()
    {
    playerMoneyText = playerMoneyTextBox.GetComponent<Text>();
    playerMoneyText.text = "Player Money: " + PlayerMoneyHandlerVR.PlayerMoney.ToString("c");
  }
}
