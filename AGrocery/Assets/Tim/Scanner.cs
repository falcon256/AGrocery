using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    Debug.Log("scanner has been triggered");
  }
}
