using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{

  
  GameObject player;
 
  float footstepTimer;
  AudioSource soundPlayer;
  GameObject soundObject;
  SoundManager soundManager;


  void Start()
  {
    player = GameObject.Find("OVRPlayerController");
    soundObject = GameObject.Find("SoundManager");
    soundPlayer = transform.GetComponent<AudioSource>();
    soundManager = soundObject.GetComponent<SoundManager>();

  }

  IEnumerator StopSound()
  {
    yield return new WaitForSeconds(soundManager.cartStop.length);
    soundPlayer.Stop();
  }

  // Update is called once per frame

  private void FixedUpdate()
  {
    if (transform.GetComponent<OVRGrabbable>().isGrabbed && player.GetComponent<PlayerSound>().isMoving == true)
    {

      if (footstepTimer > .7f)
      {
        soundPlayer.volume = .3f;
        soundPlayer.PlayOneShot(soundManager.cartWheels);



        footstepTimer = 0;
      }



      transform.rotation = player.transform.rotation;



    }
   

    footstepTimer += Time.deltaTime;

  }
  void Update()
  {
   


  }

}
