using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateDoor : MonoBehaviour
{
  [SerializeField] GameObject door_A;
  [SerializeField] GameObject door_B;
  [SerializeField] GameObject door_C;
  [SerializeField] GameObject door_D;

  AudioSource soundPlayer;

    private void Start()
  {
    soundPlayer = gameObject.GetComponent<AudioSource>();
  }


  private void OnTriggerEnter(Collider other)
  {
    if(this.gameObject.name == "Door Trigger 1")
    {
      door_A.GetComponent<PlayableDirector>().Play();
      soundPlayer.Play();
      Invoke("PauseDirector", 2f);
    }

    if(this.gameObject.name == "Door Trigger 2")
    {
      door_C.GetComponent < PlayableDirector>().Play();
      soundPlayer.Play();
      Invoke("PauseDirector", 2f);
    }
   
  
  }

  private void PauseDirector()
  {
    if (this.gameObject.name == "Door Trigger 1")
    {
      door_A.GetComponent<PlayableDirector>().Pause();
    }

    if (this.gameObject.name == "Door Trigger 2")
    {
      door_C.GetComponent<PlayableDirector>().Pause();
    }
    
  }
  private void OnTriggerExit(Collider other)
  {
    if (this.gameObject.name == "Door Trigger 1")
    {
      door_A.GetComponent<PlayableDirector>().Resume();
      soundPlayer.Play();
    }

    if (this.gameObject.name == "Door Trigger 2")
    {
      door_C.GetComponent<PlayableDirector>().Resume();
      soundPlayer.Play();
    }
    
  }


}
