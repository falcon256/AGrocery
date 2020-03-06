using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductColliderScript : MonoBehaviour
{
    PlayerMoneyHandler playerMoneyHandler;

    public GameObject player;
    public Transform playerHand;
    //public GameObject product;

    Vector3 startPos;

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
        //totalMoneyTextBox = GameObject.FindWithTag("TotalMoneyText");\
        startPos = this.transform.position;

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
                Destroy(gameObject);
            }
            if (holdingProduct && Input.GetKeyDown(KeyCode.R))
            {
                this.gameObject.GetComponent<ItemPickup>().enabled = false;
                holdingProduct = false;
            }
        }
        if (product.gameObject.tag == "CheckoutCounter")
        {
            if (player.GetComponent<PlayerColliderScript>().atCheckoutCounter == true && Input.GetKeyDown(KeyCode.E))
            {
                //transform.position = startPos;
                //Destroy(gameObject);
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
