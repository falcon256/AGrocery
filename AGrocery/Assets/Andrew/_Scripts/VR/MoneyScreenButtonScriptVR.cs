using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyScreenButtonScriptVR : MonoBehaviour
{
  public GameObject player;


  public GameObject currentOfferCheckoutTextBox;
  public TextMeshProUGUI currentOfferCheckoutText;

  // Start is called before the first frame update
  public void Start()
  {
    player = GameObject.FindWithTag("Player");

    currentOfferCheckoutTextBox = GameObject.FindWithTag("CurrentOfferCheckoutText");

  }
  // Update is called once per frame
  void Update()
  {
  }

  public void addPenny()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer + PlayerMoneyHandler.Penny;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TMPro.TextMeshProUGUI>();

    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void addNickel()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer + PlayerMoneyHandler.Nickel;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void addDime()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer + PlayerMoneyHandler.Dime;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void addQuarter()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer + PlayerMoneyHandler.Quarter;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void addOneDollarBill()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer + PlayerMoneyHandler.OneDollar;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void addFiveDollarBill()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer + PlayerMoneyHandler.FiveDollars;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void addTenDollarBill()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer + PlayerMoneyHandler.TenDollars;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void addTwentyDollarBill()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer + PlayerMoneyHandler.TwentyDollars;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }

  public void removePenny()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer - PlayerMoneyHandler.Penny;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void removeNickel()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer - PlayerMoneyHandler.Nickel;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void removeDime()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer - PlayerMoneyHandler.Dime;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void removeQuarter()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer - PlayerMoneyHandler.Quarter;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void removeOneDollarBill()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer - PlayerMoneyHandler.OneDollar;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
    // "Current Offer: " + "$" + PlayerMoneyHandler.CurrentOffer;
  }
  public void removeFiveDollarBill()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer - PlayerMoneyHandler.FiveDollars;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void removeTenDollarBill()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer - PlayerMoneyHandler.TenDollars;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
  public void removeTwentyDollarBill()
  {
    PlayerMoneyHandler.CurrentOffer = PlayerMoneyHandler.CurrentOffer - PlayerMoneyHandler.TwentyDollars;

    currentOfferCheckoutText = currentOfferCheckoutTextBox.GetComponent<TextMeshProUGUI>();
    currentOfferCheckoutText.text = "Current Offer: " + PlayerMoneyHandler.CurrentOffer.ToString("c");
  }
}