using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomHand : MonoBehaviour
{
    public GameObject dollarCopy;
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
            if (RightIndexDown())
            {
                if (holdingDollar == false)
                {
                    TakeMoney();
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

    private void TakeMoney()
    {
        holdingDollar = true;
        dollar = Instantiate(dollarCopy);
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
