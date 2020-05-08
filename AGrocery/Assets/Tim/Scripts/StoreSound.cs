using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSound : MonoBehaviour
{
  AudioSource ac;

  private void Start()
  {
    ac = GetComponent<AudioSource>();
    ac.mute = true;
  }
  private void OnTriggerEnter(Collider other)
  {
    if(other.tag == "Player")
    {
      ac.mute = false;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    ac.mute = true;
  }

  private void OnTriggerStay(Collider other)
  {
    if (other.tag == "Player")
    {
      ac.mute = false;

    }
  
  }

 



}
