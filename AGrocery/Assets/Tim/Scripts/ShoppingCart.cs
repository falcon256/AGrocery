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
  //OvrAvatar avatar;
  //GameObject cartHand1;
  //GameObject cartHand2;
  [SerializeField] GameObject leftHand;
  [SerializeField] GameObject rightHand;
  public Transform camTransform;
  public float distanceFromCamera;



  void Start()
  {
    player = GameObject.Find("OVRPlayerController");
    soundObject = GameObject.Find("SoundManager");
    soundPlayer = transform.GetComponent<AudioSource>();
    soundManager = soundObject.GetComponent<SoundManager>();
    //cartHand1 = GameObject.Find("CartHand1");
    //cartHand2 = GameObject.Find("CartHand2");

    //avatar = GameObject.Find("LocalAvatar").GetComponent<OvrAvatar>();

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



      //transform.rotation = player.transform.rotation;



    }
   

    footstepTimer += Time.deltaTime;

  }
  void Update()
  {

    if (transform.GetComponent<OVRGrabbable>().isGrabbed)
    {
      //avatar.ShowFirstPerson = false;
      //cartHand1.SetActive(true);
      //cartHand2.SetActive(true);

      gameObject.transform.localPosition = new Vector3(player.transform.localPosition.x + 1.2f, gameObject.transform.position.y, player.transform.localPosition.z) ;

  

      

    }
    else {
      //avatar.ShowFirstPerson = true;
      //cartHand1.SetActive(false);
      //cartHand2.SetActive(false);
    }

  }

}
