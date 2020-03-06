using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditCardProcessor : MonoBehaviour
{
  public GameObject payScreen;
  PayScreen payScreenScript;
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

  //ScannerColliderScriptVR scanScript;
  void Start()
  {
    payScreen = new List<GameObject>(GameObject.FindGameObjectsWithTag("Payscreen")).Find(g => g.transform.parent.gameObject);
    payScreenScript = payScreen.GetComponent<PayScreen>();
    audioSource1 = gameObject.GetComponent<AudioSource>();
    audioSourceOther = payScreenScript.audioSource2;
    _mainText = new StringBuilder();




  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {
    //payScreen = GetComponentInParent<PayScreen>();


    if (other.gameObject.tag == "CreditCard")
    {
      ProcessCreditPayment();
    }
  }

  public void ProcessCreditPayment()
  {

    // _mainText.Clear();
    // _mainText.Append("Thank You! \n Have a nice day!");
    //payScreenScript.outputTotalText.text = $"{0:c}";
    //payScreenScript.itemizedText.text = String.Empty;
    // payScreenScript.mainText.text = _mainText.ToString();

    audioSource1.PlayOneShot(clip5);
    StartCoroutine("PaymentConfirmation");






    // payScreenScript.cashButton.SetActive(false);
    // payScreenScript.creditButton.SetActive(false);
    //payScreenScript.okButton.SetActive(true);
  }
  IEnumerator PaymentConfirmation()
  {
    yield return new WaitForSeconds(clip5.length + 5f);

    audioSource1.PlayOneShot(clip6);
    payScreenScript.outputTotalText.text = $"{0:c}";
    payScreenScript.itemizedText.text = String.Empty;
    _mainText.Clear();
    _mainText.Append("Thank You! \n Have a nice day!");
    payScreenScript.mainText.text = _mainText.ToString();
    payScreenScript.cashButton.SetActive(false);
    payScreenScript.creditButton.SetActive(false);

    StartCoroutine("ReturnToStart");
  }
  IEnumerator ReturnToStart()
  {

    yield return new WaitForSeconds(clip6.length + 2f);
    payScreenScript.mainText.text = String.Empty;
    audioSource1.PlayOneShot(clip7);

    payScreenScript.okButton.SetActive(true);
  }

}
  

  