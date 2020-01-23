using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartColliderScript : MonoBehaviour
{
    public GameObject player;
    public Transform playerHand;
    public GameObject cart;

    public bool closeToCart = false;
    public bool holdingCart = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (GameObject.FindWithTag("ShoppingCartLocation"))
        {
            playerHand = GameObject.FindWithTag("ShoppingCartLocation").transform;
        }        
        cart = GameObject.FindWithTag("ShoppingCart");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider cart)
    {
        closeToCart = true;
        if (cart.gameObject.tag == "Player")
        {
            //Debug.Log("PlayerCollision!");
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.GetComponent<ItemPickupShoppingCart>().enabled = true;
                holdingCart = true;
                closeToCart = false;
            }
            if (holdingCart && Input.GetKeyDown(KeyCode.R))
            {
                this.gameObject.GetComponent<ItemPickupShoppingCart>().enabled = false;
                holdingCart = false;
            }
        }
    }

        void OnTriggerExit(Collider cart)
        {
            if (cart.gameObject.tag == "Player")
            {
            holdingCart = false;
            closeToCart = false;
            }
        }

    }
