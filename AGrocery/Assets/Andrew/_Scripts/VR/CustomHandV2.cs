using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomHandV2 : MonoBehaviour
{
    public GameObject oneDollar;
    public GameObject fiveDollar;
    public GameObject tenDollar;
    public GameObject twentyDollar;
    public GameObject fiftyDollar;
    public GameObject penny;
    public GameObject nickel;
    public GameObject dime;
    public GameObject quarter;
    public GameObject creditCard;

    public GameObject playerMoneyTextBox;
    public Text playerMoneyText;

    public Text debug;

    private bool holdingDollar;
    private GameObject dollar;
    private Transform offset;

    private void Start()
    {
        playerMoneyTextBox = GameObject.FindWithTag("PlayerMoneyText");

        offset = GameObject.FindGameObjectWithTag("hand").transform;
        holdingDollar = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "icon" && PlayerMoneyHandlerVR.PlayerMoney > 0)
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
            if (other.name == "CreditCard")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeCreditCard();
                    }
                }
            }
            if (other.name == "Penny")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyPenny();
                    }
                }
            }
            if (other.name == "Nickel")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyNickel();
                    }
                }
            }
            if (other.name == "Dime")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyDime();
                    }
                }
            }
            if (other.name == "Quarter")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyQuarter();
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

        playerMoneyText = playerMoneyTextBox.GetComponent<Text>();
        playerMoneyText.text = "Player Money: " + PlayerMoneyHandlerVR.PlayerMoney.ToString("c");

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

        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 1.00f;
    }

    private void TakeMoneyFiveDollar()
    {
        holdingDollar = true;
        dollar = Instantiate(fiveDollar);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 5.00f;
    }

    private void TakeMoneyTenDollar()
    {
        holdingDollar = true;
        dollar = Instantiate(tenDollar);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());

        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 10.00f;
    }

    private void TakeMoneyTwentyDollar()
    {
        holdingDollar = true;
        dollar = Instantiate(twentyDollar);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());

        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 20.00f;
    }

    private void TakeMoneyFiftyDollar()
    {
        holdingDollar = true;
        dollar = Instantiate(fiftyDollar);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());

        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 50.00f;
    }

    private void TakeCreditCard()
    {
        holdingDollar = true;
        dollar = Instantiate(creditCard);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());        
    }

    private void TakeMoneyPenny()
    {
        holdingDollar = true;
        dollar = Instantiate(penny);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 0.01f;
    }

    private void TakeMoneyNickel()
    {
        holdingDollar = true;
        dollar = Instantiate(nickel);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());

        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 0.05f;
    }

    private void TakeMoneyDime()
    {
        holdingDollar = true;
        dollar = Instantiate(dime);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());

        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 0.10f;
    }

    private void TakeMoneyQuarter()
    {
        holdingDollar = true;
        dollar = Instantiate(quarter);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());

        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 0.25f;
    }

    private void DropMoney()
    {
        holdingDollar = false;
        dollar.transform.parent = null;
        //dollar.GetComponent<Rigidbody>().useGravity = true;
        //dollar.GetComponent<Rigidbody>().isKinematic = false;
        //dollar.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
