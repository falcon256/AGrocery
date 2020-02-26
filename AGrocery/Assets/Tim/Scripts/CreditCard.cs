using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCard : MonoBehaviour
{
    PayScreen payScreen;
    //ScannerColliderScriptVR scanScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnTriggerExit(Collider other)
  {
        payScreen = GetComponentInParent<PayScreen>();
      

        if (other.gameObject.tag == "CardInsert")
        {
            payScreen.ZeroOutTotal();
        }
  }
}
