using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartItem : MonoBehaviour
{


  Rigidbody rb;
  bool isCartItem;
  CharacterController characterController;
  GameObject otherGameObject;
 
 

  private void Start()
  {

    rb = gameObject.GetComponent<Rigidbody>();
    characterController = GameObject.Find("OVRPlayerController").GetComponent<CharacterController>();

  }
  private void OnTriggerEnter(Collider other)
  {

   
    if (other.gameObject.tag == "ShoppingCart")
    {
      otherGameObject = other.gameObject;
      isCartItem = true;


      if (isCartItem == true)
      {
        if (characterController.isGrounded == true && characterController.velocity.magnitude > .02f && other.GetComponent<ShoppingCart>().isGrabbed == true)
        {
       
          rb.constraints = RigidbodyConstraints.FreezeAll;
          gameObject.transform.parent = other.transform;
        }

      }

    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "ShoppingCart")
    {
      isCartItem = false;

    }
  }

  void Update()
  {

    if(otherGameObject != null)
    {
      if (otherGameObject.GetComponent<ShoppingCart>().isGrabbed == false && otherGameObject.GetComponent<ShoppingCart>().enabled == false)
      {
        rb.constraints = RigidbodyConstraints.None;
        gameObject.transform.parent = null;
      }
    }

    if(gameObject.GetComponent<OVRGrabbable>().isGrabbed == true && isCartItem == true)
    {
      gameObject.transform.parent = null;
    }




  }
}
