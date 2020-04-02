using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartItem : MonoBehaviour
{


  Rigidbody rb;
  bool isCartItem;
  CharacterController characterController;
  GameObject otherGameObject;

  float time = 2;
  float timer;

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

        timer += Time.deltaTime;
        gameObject.transform.parent = other.transform;
        if (characterController.isGrounded == true && characterController.velocity.magnitude > .02f && other.GetComponent<ShoppingCart>().isGrabbed == true)
        {
       
          rb.constraints = RigidbodyConstraints.FreezeAll;
        
        }

      }
    

    }
  }

  private void OnTriggerStay(Collider other)
  {

    isCartItem = true;
    if (isCartItem && timer >= time )
    {
      rb.Sleep();
      rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
      rb.drag = 5;
     
    
      // transform.localPosition = new Vector3(0, 0, 0);
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "ShoppingCart")
    {
      isCartItem = false;
      timer = 0;
    }
  }

  void Update()
  {

    if(otherGameObject != null)
    {
      if (otherGameObject.GetComponent<ShoppingCart>().isGrabbed == false && otherGameObject.GetComponent<ShoppingCart>().isDisabled == true)
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
