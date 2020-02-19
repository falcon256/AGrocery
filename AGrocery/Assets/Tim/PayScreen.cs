using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PayScreen : MonoBehaviour
{
  public GameObject cashButton;
  public GameObject creditButton;
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
    cashButton = new List<GameObject>(GameObject.FindGameObjectsWithTag("CreditButton")).Find(g => g.transform.IsChildOf(this.transform));
    itemizedTextObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("PayScreenItemizedText")).Find(g => g.transform.IsChildOf(this.transform));
    outputTotalTextObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("PayScreenOutputText")).Find(g => g.transform.IsChildOf(this.transform));
    itemizedText = itemizedTextObject.GetComponent<TMPro.TextMeshProUGUI>();
    outputTotalText = outputTotalTextObject.GetComponent<TMPro.TextMeshProUGUI>();
  
  }
  public void OnClickCash()
  {
    Debug.Log("You have chosen the cash payment method");
  }

  public void OnClickCredit()
  {
    Debug.Log("You have chosen the credit payment method");
  }
  
}
