using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class TotalCostHandler : MonoBehaviour
{

    public StringBuilder outputTotalText;
    public StringBuilder itemizedText;
    public PayScreen payScreen;
    public float productTotal = 0;
    public float productCost;
    public string productName;

    float scanTime = .5f;
    float scanTimer = 0;
    bool scannable = true;

    public static float total;
    public static float newTotal;

    public float currentTotal;
    public float currentNewTotal;


    // Start is called before the first frame update
    void Start()
    {
        payScreen = GetComponentInChildren<PayScreen>();
    }

    // Update is called once per frame
    void Update()
    {
    currentTotal = total;
    currentNewTotal = newTotal;
}
}
