using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayScreen : MonoBehaviour
{
  public GameObject cashButton;
  public GameObject creditButton;

  public bool isCredit;

  public void OnClickCash()
  {
    Debug.Log("You have chosen the cash payment method");
  }

  public void OnClickCredit()
  {
    Debug.Log("You have chosen the credit payment method");
  }
  
}
