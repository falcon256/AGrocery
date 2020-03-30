using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorColliderScriptVR : MonoBehaviour
{
    public GameObject player;
    public Transform playerHand;
    //public GameObject product;

    public Animator doorAnims;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHand = GameObject.FindWithTag("PlayerGrabLocation").transform;
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnTriggerEnter(Collider player)
    {       
        if (player.gameObject.tag == "Player")
        {
            doorAnims.SetBool("isOpening", true);
            doorAnims.SetBool("isClosing", false);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.storeDoors);
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            doorAnims.SetBool("isClosing", true);
            doorAnims.SetBool("isOpening", false);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.storeDoors);
        }
    }   
}
