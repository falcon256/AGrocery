using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductInitiator : MonoBehaviour
{
  public float distanceToPlayer;
  Transform player;
  Rigidbody rb;
  OVRGrabbable grabbable;
  CartItem cartItem;
  BaggedItem baggedItem;

  private void Awake()
  {
    cartItem = GetComponent<CartItem>();
    baggedItem = GetComponent<BaggedItem>();





  }

  void Start()
  {

    player = GameObject.FindGameObjectWithTag("Player").transform;





  }


  void Update()
  {
    distanceToPlayer = Vector3.Distance(transform.position, player.position);









  }

}