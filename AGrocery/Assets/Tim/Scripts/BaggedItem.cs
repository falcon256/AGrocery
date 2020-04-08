using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggedItem : MonoBehaviour
{

  bool isBagged = false;
    void Start()
    {
        
    }

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "grocery-bag" && gameObject.GetComponent<OVRGrabbable>().isGrabbed == false)
    {
      isBagged = true;
      gameObject.transform.parent = other.transform;
      gameObject.GetComponent<Rigidbody>().drag = 7;
     // Destroy(gameObject);
    }
  }

  //private void OnTriggerStay(Collider other)
  //{

  //  isCartItem = true;
  //  if (isCartItem && timer >= time)
  //  {
  //    rb.Sleep();
  //    rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
  //    rb.drag = 5;


  //    // transform.localPosition = new Vector3(0, 0, 0);
  //  }
  //}

  // Update is called once per frame
  void Update()
    {
        
    }
}
