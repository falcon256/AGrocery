using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandV2 : MonoBehaviour
{
  private GameObject wallet;
  public GameObject coins;
  public GameObject dollars;
  public GameObject deposit;

  private void Start()
  {
    wallet = GameObject.FindGameObjectWithTag("Wallet");
    coins = GameObject.FindGameObjectWithTag("Coins");
    dollars = GameObject.FindGameObjectWithTag("Dollars");
    deposit = GameObject.FindGameObjectWithTag("SavePanel");

    coins.SetActive(false);
    wallet.SetActive(false);
    deposit.SetActive(false);

  }
  private void Update()
  {
    if (LeftHandOpen())
    {
      Open();
    }
    else
    {
      Close();
    }

    if (wallet)
    {
      if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
      {
        dollars.SetActive(false);
        coins.SetActive(true);
        deposit.SetActive(true);
      }
      else
      {
        dollars.SetActive(true);
        coins.SetActive(false);
        deposit.SetActive(false);
      }
    }



  }
  public void Open()
  {
    wallet.SetActive(true);
  }

  public void Close()
  {
    wallet.SetActive(false);
  }

  public bool LeftHandOpen()
  {
    return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
  }
}
