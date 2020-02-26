using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PayScreen : MonoBehaviour
{
  public GameObject payButton;
  public GameObject cashButton;
  public GameObject creditButton;
  public GameObject cardInsert;
  public GameObject cardSwipe;

  public Canvas payScreenCanvas;
  public GameObject outputTotalTextObject;
  public TextMeshProUGUI outputTotalText;
  public GameObject itemizedTextObject;
  public TextMeshProUGUI itemizedText;


  public bool isCredit;


  private void Start()
  {
    payScreenCanvas = gameObject.GetComponent<Canvas>();
    cashButton = new List<GameObject>(GameObject.FindGameObjectsWithTag("CashButton")).Find(g => g.transform.IsChildOf(this.transform));
    creditButton = new List<GameObject>(GameObject.FindGameObjectsWithTag("CreditButton")).Find(g => g.transform.IsChildOf(this.transform));
    payButton = new List<GameObject>(GameObject.FindGameObjectsWithTag("PayButton")).Find(g => g.transform.IsChildOf(this.transform));
    cardSwipe = new List<GameObject>(GameObject.FindGameObjectsWithTag("CardSwipe")).Find(g => g.transform.IsChildOf(this.transform));
    cardInsert = new List<GameObject>(GameObject.FindGameObjectsWithTag("CardInsert")).Find(g => g.transform.IsChildOf(this.transform));

    itemizedTextObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("PayScreenItemizedText")).Find(g => g.transform.IsChildOf(this.transform));
    outputTotalTextObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("PayScreenOutputText")).Find(g => g.transform.IsChildOf(this.transform));
    itemizedText = itemizedTextObject.GetComponent<TMPro.TextMeshProUGUI>();
    outputTotalText = outputTotalTextObject.GetComponent<TMPro.TextMeshProUGUI>();
    creditButton.SetActive(false);
    cashButton.SetActive(false);
    cardSwipe.SetActive(false);
    cardInsert.SetActive(false);
  
  }

  public void OnClickPay()
  {
    payButton.SetActive(false);
    creditButton.SetActive(true);
    cashButton.SetActive(true);
  }
  public void OnClickCash()
  {
    Debug.Log("You have chosen the cash payment method");
   


  }

  public void OnClickCredit()
  {
    Debug.Log("You have chosen the credit payment method");

    cardSwipe.SetActive(true);
    cardInsert.SetActive(true);
  }

    public void ZeroOutTotal()
    {
        outputTotalText.text = "0.00";
    }
  
}
