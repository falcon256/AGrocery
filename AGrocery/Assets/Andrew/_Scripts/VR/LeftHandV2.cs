using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandV2 : MonoBehaviour
{
    private GameObject wallet;

    private void Start()
    {
        wallet = GameObject.FindGameObjectWithTag("Wallet");
        wallet.SetActive(false);
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
        return OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
    }
}
