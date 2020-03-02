using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class CreditCardValue : MonoBehaviour
{

    public float creditCardValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        creditCardValue = PlayerMoneyHandler.PlayerMoney;

        this.gameObject.GetComponent<MoneyData>().value = creditCardValue;

    }
}
