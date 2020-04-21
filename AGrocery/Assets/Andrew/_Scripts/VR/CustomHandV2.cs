using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomHandV2 : MonoBehaviour
{
  public GameObject creditCard;
  public GameObject oneDollar;
  public GameObject fiveDollar;
  public GameObject tenDollar;
  public GameObject twentyDollar;
  public GameObject fiftyDollar;

  public Text debug;

  private bool holdingDollar;
  private GameObject dollar;
  private Transform offset;

  private void Start()
  {
    offset = GameObject.FindGameObjectWithTag("hand").transform;
    holdingDollar = false;
  }

  private void OnTriggerStay(Collider other)
  {
    if (other.tag == "icon")
    {
      if (other.name == "One")
      {
        if (RightIndexDown())
        {
          if (holdingDollar == false)
          {
            TakeMoneyOneDollar();
          }
        }
      }

      if (other.name == "Five")
      {
        if (RightIndexDown())
        {
          if (holdingDollar == false)
          {
            TakeMoneyFiveDollar();
          }
        }
      }

      if (other.name == "Ten")
      {
        if (RightIndexDown())
        {
          if (holdingDollar == false)
          {
            TakeMoneyTenDollar();
          }
        }
      }

      if (other.name == "Twenty")
      {
        if (RightIndexDown())
        {
          if (holdingDollar == false)
          {
            TakeMoneyTwentyDollar();
          }
        }
      }

      if (other.name == "Fifty")
      {
        if (RightIndexDown())
        {
          if (holdingDollar == false)
          {
            TakeMoneyFiftyDollar();
          }
        }
      }

      if (other.name == "Credit")
      {
        if (RightIndexDown())
        {
          if (holdingDollar == false)
          {
            TakeMoneyCreditCard();
          }
        }
      }


    }
  }

  private void Update()
  {
    if (RightIndexUp())
    {
      if (holdingDollar == true)
      {
        DropMoney();
      }
    }

    else if (GetRightHand())
    {
      if (holdingDollar == true)
      {
        UpdateLocation();
      }
    }
  }

  public void UpdateLocation()
  {
    dollar.transform.localPosition = offset.position;
    dollar.transform.localRotation = offset.rotation;
  }

  public bool RightIndexDown()
  {
    return OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
  }

  public bool GetRightHand()
  {
    return OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
  }

  public bool RightIndexUp()
  {
    return OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger);
  }

  private void TakeMoneyOneDollar()
  {
    holdingDollar = true;
    dollar = Instantiate(oneDollar);
    //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
  }

  private void TakeMoneyFiveDollar()
  {
    holdingDollar = true;
    dollar = Instantiate(fiveDollar);
    //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
  }

  private void TakeMoneyTenDollar()
  {
    holdingDollar = true;
    dollar = Instantiate(tenDollar);
    //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
  }

  private void TakeMoneyTwentyDollar()
  {
    holdingDollar = true;
    dollar = Instantiate(twentyDollar);
    //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
  }

  private void TakeMoneyFiftyDollar()
  {
    holdingDollar = true;
    dollar = Instantiate(fiftyDollar);
    //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
  }

  private void TakeMoneyCreditCard()
  {
    holdingDollar = true;
    dollar = Instantiate(creditCard);
    //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
  }


  private void DropMoney()
  {
    holdingDollar = false;
    dollar.transform.parent = null;
    dollar.GetComponent<Rigidbody>().useGravity = true;
    dollar.GetComponent<Rigidbody>().isKinematic = false;
    dollar.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
  }
}
