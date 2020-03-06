using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColliderScriptBackup : MonoBehaviour
{
    public GameObject player;
    public Transform playerHand;
    //public GameObject product;

    public GameObject totalMoneyTextBox;
    public Text totalMoneyText;

    public bool closeToProduct = false;
    public bool holdingProduct = false;
    public bool atCheckoutCounter = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHand = GameObject.FindWithTag("PlayerGrabLocation").transform;
        totalMoneyTextBox = GameObject.FindWithTag("TotalMoneyText");
        //product = GameObject.FindWithTag("Product");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (closeToProduct1 && Input.GetKeyDown(KeyCode.E))
        {
         product1.GetComponent<ItemPickup>().enabled = true;
        }
        if (closeToProduct2 && Input.GetKeyDown(KeyCode.E))
        {
            product2.GetComponent<ItemPickup>().enabled = true;
        }
        if (closeToProduct3 && Input.GetKeyDown(KeyCode.E))
        {
            product3.GetComponent<ItemPickup>().enabled = true;
        }*/
    }

    void OnTriggerStay(Collider product)
    {
        if (product.gameObject.tag == "Product1")
        {
            closeToProduct = true;
            //Debug.Log("PlayerCollision!");
            if (closeToProduct && Input.GetKeyDown(KeyCode.E))
            {
                PlayerMoneyHandler.TotalCost += 1.00m;

                totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;
                holdingProduct = true;
            }
        }
        if (product.gameObject.tag == "Product2")
        {
            closeToProduct = true;
            //Debug.Log("PlayerCollision!");
            if (closeToProduct && Input.GetKeyDown(KeyCode.E))
            {
                PlayerMoneyHandler.TotalCost += 1.50m;

                totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;
                holdingProduct = true;
            }
        }
        if (product.gameObject.tag == "Product3")
        {
            closeToProduct = true;
            //Debug.Log("PlayerCollision!");
            if (closeToProduct && Input.GetKeyDown(KeyCode.E))
            {
                PlayerMoneyHandler.TotalCost += 2.00m;

                totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;
                holdingProduct = true;
            }
        }
        if (product.gameObject.tag == "CheckoutCounter")
        {
            atCheckoutCounter = true;
            if (holdingProduct && Input.GetKeyDown(KeyCode.R))
            {

                PlayerMoneyHandler.TotalCost = 0.00m;

                totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;
            }
            if (holdingProduct && atCheckoutCounter && Input.GetKeyDown(KeyCode.E))
            {

            }
        }
        else
        {
            atCheckoutCounter = false;
        }
    }

    void OnTriggerExit(Collider product)
    {
        if (product.gameObject.tag == "Product1" && product.gameObject.tag == "Product2" && product.gameObject.tag == "Product3")
        {
            closeToProduct = false;
            holdingProduct = false;
        }
    }


}
