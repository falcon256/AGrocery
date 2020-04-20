using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicsCollisionTrigger : MonoBehaviour
{
  private GameObject firstCollider = null;
  private Rigidbody myRB = null;
  public void OnCollisionEnter(Collision collision)
  {

    if (this.gameObject.GetComponent<Rigidbody>() == null && collision.gameObject == firstCollider)
      return;
    if (this.gameObject.GetComponent<Rigidbody>())
    {
      if (!firstCollider)
      {
        firstCollider = collision.gameObject;
        myRB = this.gameObject.GetComponent<Rigidbody>();
        if (!myRB)
        {
          Debug.LogError("There is no Rigib Body on this object, but you added Dan's RB disabler onto it...");
        }
        else
        {
          Destroy(myRB);
          myRB = null;
        }
      }
    }
    else
    {
      setupRB();
      return;
    }
  }

  public void setupRB()
  {
    if (myRB)
      return;

    myRB = this.gameObject.AddComponent<Rigidbody>();
    myRB.mass = 0.1f;
    myRB.isKinematic = false;
    myRB.useGravity = true;
    return;
  }
}