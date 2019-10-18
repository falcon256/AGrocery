using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product2ColliderScript : MonoBehaviour
{
    PlayerMoneyHandler playerMoneyHandler;

    public GameObject player;
    public Transform playerHand;
    //public GameObject product;

    public GameObject totalMoneyTextBox;
    public Text totalMoneyText;

    public bool closeToProduct = false;
    public bool holdingProduct = false;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHand = GameObject.FindWithTag("PlayerGrabLocation").transform;
        //product = GameObject.FindWithTag("Product");
        //totalMoneyTextBox = GameObject.FindWithTag("TotalMoneyText");

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider product)
    {
        closeToProduct = true;
        if (product.gameObject.tag == "Player")
        {
            //Debug.Log("PlayerCollision!");
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.GetComponent<ItemPickup>().enabled = true;
                holdingProduct = true;
                closeToProduct = false;
            }
        }
            if (product.gameObject.name == "CheckoutCounterCollider")
            {
                if (holdingProduct && Input.GetKeyDown(KeyCode.R))
                {
                    PlayerMoneyHandler.TotalCost += 2.00m;

                    totalMoneyText = totalMoneyTextBox.GetComponent<Text>();
                    totalMoneyText.text = "Total Cost: " + PlayerMoneyHandler.TotalCost;
                    this.gameObject.GetComponent<ItemPickup>().enabled = false;
                    holdingProduct = false;
                }
            }
        }

    void OnTriggerExit(Collider product)
    {
        if (product.gameObject.tag == "Player")
        {
            closeToProduct = false;
            holdingProduct = false;
        }
    }


}
