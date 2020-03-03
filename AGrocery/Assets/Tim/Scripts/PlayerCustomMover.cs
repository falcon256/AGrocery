using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomMover : MonoBehaviour
{
  CharacterController characterController;
  GameObject camRig;
  Vector3 fwd;
    void Start()
    {
    characterController = gameObject.GetComponent < CharacterController>();
    camRig = GameObject.Find("OVRCameraRig");
    fwd = camRig.transform.TransformDirection(Vector3.forward);
    }

  // Update is called once per frame
  void Update()
  {
    if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
    { 

      var distance = 1f;
      transform.position = transform.position + -Camera.main.transform.forward * distance * Time.deltaTime;
    }
  }
}
