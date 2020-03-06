using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorColliderScriptVR : MonoBehaviour
{
  public GameObject player;
  public Transform playerHand;
  AudioSource soundPlayer;
  SoundManager soundManager;
  //public GameObject product;

  public Animator doorAnims;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.FindWithTag("Player");
    playerHand = GameObject.FindWithTag("PlayerGrabLocation").transform;
    soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    soundPlayer = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {


  }
  void OnTriggerEnter(Collider player)
  {
    Debug.Log("doors should open");
    doorAnims.SetBool("isOpening", true);
    doorAnims.SetBool("isClosing", false);
    soundPlayer.volume = .1f;
    soundPlayer.PlayOneShot(soundManager.storeDoors);
  }

  void OnTriggerExit(Collider player)
  {
    Debug.Log("doors should close");
    doorAnims.SetBool("isClosing", true);
    doorAnims.SetBool("isOpening", false);
    soundPlayer.volume = .1f;
    soundPlayer.PlayOneShot(soundManager.storeDoors);
  }
}
