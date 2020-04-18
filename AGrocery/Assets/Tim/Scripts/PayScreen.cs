using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using TMPro;

public class PayScreen : MonoBehaviour
{
  public GameObject okButton;
  public GameObject cashButton;
  public GameObject creditButton;
  public GameObject cardInsert;
  public GameObject cardSwipe;

  public CreditCardProcessor insertProcessScript;
  public Canvas payScreenCanvas;
  public GameObject outputTotalTextObject;
  public TextMeshProUGUI outputTotalText;
  public GameObject itemizedTextObject;
  public TextMeshProUGUI itemizedText;
  public GameObject changeTextObject;
  public TextMeshProUGUI changeText;
  public GameObject mainTextObject;
  public TextMeshProUGUI mainText;
  public StringBuilder _mainText;
  public AudioSource audioSource2;
  public AudioSource audioSource1;

  public AudioClip clip1;
  public AudioClip clip2;
  public AudioClip clip3;
  public AudioClip clip4;
  public AudioClip clip5;
  public AudioClip clip6;
  public AudioClip clip7;
  public AudioClip clip8;



  public bool isCredit;


  private void Start()
  {
    payScreenCanvas = gameObject.GetComponent<Canvas>();
    cashButton = new List<GameObject>(GameObject.FindGameObjectsWithTag("CashButton")).Find(g => g.transform.IsChildOf(this.transform));
    creditButton = new List<GameObject>(GameObject.FindGameObjectsWithTag("CreditButton")).Find(g => g.transform.IsChildOf(this.transform));
    okButton = new List<GameObject>(GameObject.FindGameObjectsWithTag("OKButton")).Find(g => g.transform.IsChildOf(this.transform));
    cardSwipe = new List<GameObject>(GameObject.FindGameObjectsWithTag("CardSwipe")).Find(g => g.transform.IsChildOf(this.transform));
    cardInsert = new List<GameObject>(GameObject.FindGameObjectsWithTag("CardInsert")).Find(g => g.transform.IsChildOf(this.transform));

    itemizedTextObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("PayScreenItemizedText")).Find(g => g.transform.IsChildOf(this.transform));
    outputTotalTextObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("PayScreenOutputText")).Find(g => g.transform.IsChildOf(this.transform));
    mainTextObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("SelfCheckMainText")).Find(g => g.transform.IsChildOf(this.transform));
    changeTextObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("ChangeText")).Find(g => g.transform.IsChildOf(this.transform));

    itemizedText = itemizedTextObject.GetComponent<TMPro.TextMeshProUGUI>();
    outputTotalText = outputTotalTextObject.GetComponent<TMPro.TextMeshProUGUI>();
    mainText = mainTextObject.GetComponent<TMPro.TextMeshProUGUI>();
    changeText = changeTextObject.GetComponent<TMPro.TextMeshProUGUI>();
    insertProcessScript = cardInsert.GetComponent<CreditCardProcessor>();
    audioSource2 = gameObject.GetComponent<AudioSource>();
    audioSource1 = insertProcessScript.audioSource1;
  
   
    creditButton.SetActive(false);
    cashButton.SetActive(false);
    cardSwipe.SetActive(false);
    cardInsert.SetActive(false);

  }

  public void OnClickOK()
  {
    okButton.SetActive(false);
    creditButton.SetActive(true);
    cashButton.SetActive(true);

    audioSource2.PlayOneShot(clip3);
  }
  public void OnClickCash()
  {
    Debug.Log("You have chosen the cash payment method");



  }

  public void OnClickCredit()
  {
    Debug.Log("You have chosen the credit payment method");

    cardSwipe.SetActive(true);
    cardInsert.SetActive(true);
    audioSource2.PlayOneShot(clip4);

  }

  //public void ProcessCreditPayment()
  //{
  //  outputTotalText.text = $"{0:c}";
  //  itemizedText.text = String.Empty;
  //}

}
