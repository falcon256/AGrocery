﻿using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditCardProcessor : MonoBehaviour
{
  public GameObject payScreen;
  public PayScreen payScreenScript;
  public GameObject creditCard;
  public GameObject outputTotalTextObject;
  public TextMeshProUGUI outputTotalText;
  public GameObject itemizedTextObject;
  public TextMeshProUGUI itemizedText;
  public GameObject mainTextObject;
  public TextMeshProUGUI mainText;
  public StringBuilder _mainText;
  public AudioClip clip4;
  public AudioClip clip5;
  public AudioClip clip6;
  public AudioClip clip7;
  public AudioClip clip8;
  public AudioSource audioSource1;
  public AudioSource audioSourceOther;

  public float processTime = 3f;
  public float processTimer;
  public bool isProcessing;
  public bool isConfirmed;

  //ScannerColliderScriptVR scanScript;

  private void Awake()
  {
    
    payScreenScript = GetComponentInParent<PayScreen>();
    audioSource1 = gameObject.GetComponent<AudioSource>();
    audioSourceOther = payScreenScript.audioSource2;
  }
  void Start()
  {
    //payScreen = new List<GameObject>(GameObject.FindGameObjectsWithTag("Payscreen")).Find(g => g.transform.parent.gameObject);
    //payScreenScript = payScreen.GetComponent<PayScreen>();
    //audioSource1 = gameObject.GetComponent<AudioSource>();
    //audioSourceOther = payScreenScript.audioSource2;
    
    _mainText = new StringBuilder();
   
    
    


  }

  // Update is called once per frame
  void Update()
  {

    if (isProcessing == true)
      creditCard.GetComponent<OVRGrabbable>().enabled = false;

    if (isProcessing)

      processTimer += Time.deltaTime;

    if(processTimer >= processTime)
    {
      isProcessing = false;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    //payScreen = GetComponentInParent<PayScreen>();
    

    if (other.gameObject.tag == "CreditCard")
    {


      creditCard = other.gameObject;
      if (payScreenScript.isCredit && isProcessing == false)
      {
        isProcessing = true;
        creditCard.transform.rotation = Quaternion.Euler(0, 0, 0);
        creditCard.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        ProcessCreditPayment();
      }
 
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "CreditCard")
    {
      
      
        creditCard.GetComponent<Rigidbody>().useGravity = true;
      
       

    }
   
    

  }

  public void ProcessCreditPayment()
  {

   

    audioSource1.PlayOneShot(clip5);
    StartCoroutine("PaymentConfirmation");

  }


  
  


  IEnumerator PaymentConfirmation()
  {
    yield return new WaitForSeconds(clip5.length + 5f);
    creditCard.GetComponent<Rigidbody>().useGravity = false;
    creditCard.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    audioSource1.PlayOneShot(clip6);
    payScreenScript.outputTotalText.text = $"{0:c}";
    payScreenScript.itemizedText.text = String.Empty;
    _mainText.Clear();
    _mainText.Append("Thank You! \n Have a nice day!");
    payScreenScript.changeText.text = "CHANGE: " + $"{0:c}";
    payScreenScript.mainText.text = _mainText.ToString();
    payScreenScript.cashButton.SetActive(false);
    payScreenScript.creditButton.SetActive(false);
    isConfirmed = true;

    StartCoroutine("ReturnToStart");
  }
  IEnumerator ReturnToStart()
  {

    yield return new WaitForSeconds(clip6.length + 2f);
    isProcessing = false;
    isConfirmed = false;
    payScreenScript.Reset();
  }

}
  

  