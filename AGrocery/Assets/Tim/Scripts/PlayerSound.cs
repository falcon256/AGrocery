using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
  AudioSource soundPlayer;
  GameObject soundObject;
  SoundManager soundManager;
  GameObject player;
  CharacterController characterController;
  float footstepTimer;
  public bool isMoving = false;

  void Start()
  {
    soundObject = GameObject.Find("SoundManager");
    soundPlayer = transform.GetComponent<AudioSource>();
    soundManager = soundObject.GetComponent<SoundManager>();
    characterController = transform.GetComponent<CharacterController>();

  }

  private void FixedUpdate()
  {
    //if (characterController.isGrounded == true && characterController.velocity.magnitude > .02f)
    //{
    //  isMoving = true;
    //  if (footstepTimer > .2f)
    //  {

    //    soundPlayer.volume = .2f;
    //    soundPlayer.PlayOneShot(soundManager.footsteps);



    //    footstepTimer = 0;
    //  }


    //  transform.rotation = player.transform.rotation;



    //}
    //else
    //{


    //  isMoving = false;
    //}

    //footstepTimer += Time.deltaTime;
  }

  void Update()
  {
    if (characterController.isGrounded == true && characterController.velocity.magnitude > .02f)
    {
      isMoving = true;
      if (footstepTimer > .5f)
      {

        soundPlayer.volume = .1f;
        soundPlayer.PlayOneShot(soundManager.footsteps);



        footstepTimer = 0;
      }


      



    }
    else
    {


      isMoving = false;
    }

    footstepTimer += Time.deltaTime;
  }


}

