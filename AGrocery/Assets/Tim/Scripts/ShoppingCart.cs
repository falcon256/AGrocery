using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{

  
  GameObject player;
  AudioSource soundPlayer;
  GameObject soundObject;
  SoundManager soundManager;
  OvrAvatar avatar;
  GameObject cartHand1;
  GameObject cartHand2;
  [SerializeField] GameObject leftHand;
  [SerializeField] GameObject rightHand;
 
  public float distanceToPlayer;
  float footstepTimer;
  public bool isGrabbed = false;

  void Start()
  {
    player = GameObject.Find("OVRPlayerController");
    soundObject = GameObject.Find("SoundManager");
    soundPlayer = transform.GetComponent<AudioSource>();
    soundManager = soundObject.GetComponent<SoundManager>();
    cartHand1 = GameObject.Find("CartHand1");
    cartHand2 = GameObject.Find("CartHand2");

    avatar = GameObject.Find("LocalAvatar").GetComponent<OvrAvatar>();

  }

  IEnumerator StopSound()
  {
    yield return new WaitForSeconds(soundManager.cartStop.length);
    soundPlayer.Stop();
  }

 

  private void FixedUpdate()
  {
    if (player.GetComponent<PlayerSound>().isMoving == true &&  isGrabbed == true)
    {

      if (footstepTimer > .7f)
      {
        soundPlayer.volume = .3f;
        soundPlayer.PlayOneShot(soundManager.cartWheels);



        footstepTimer = 0;
      }




    }
   

    footstepTimer += Time.deltaTime;

  }
  void Update()
  {

    distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
    
    GameObject rotateAnchor = GameObject.Find("TrackerAnchor");

    if (distanceToPlayer <= 2.2 && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0 || OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0))
    {
      isGrabbed = true;

      if (isGrabbed)
      {
        avatar.ShowFirstPerson = false;
        cartHand1.SetActive(true);
        cartHand2.SetActive(true);

    
        gameObject.transform.parent = rotateAnchor.transform;
      }
      
    }
    else
    {
      isGrabbed = false;

      gameObject.transform.parent = null;
      avatar.ShowFirstPerson = true;
      cartHand1.SetActive(false);
      cartHand2.SetActive(false);
    }

  
  

  }

}
