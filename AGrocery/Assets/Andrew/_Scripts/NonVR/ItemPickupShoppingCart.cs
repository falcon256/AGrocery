using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupShoppingCart : MonoBehaviour
{
    public GameObject player;
    public Transform playerHand;

    //public int count;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //playerHand = GameObject.FindWithTag("ShoppingCartLocation").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the items transform to the player's hand and destroys the object if R is pressed

        //GetComponent<Rigidbody>().isKinematic = true;
        //GetComponent<Rigidbody>().useGravity = false;
        transform.position = playerHand.transform.position;
        transform.rotation = playerHand.transform.rotation;
    }
}
