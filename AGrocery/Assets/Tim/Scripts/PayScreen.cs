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
  public GameObject scanner;
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

  public decimal originalTotal;
 



  public bool isCredit;
  public bool isCash;


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

  IEnumerator RemoveMainText()
  {
    yield return new WaitForSeconds(5f);
    mainText.text = String.Empty;
  }
  public void OnClickOK()
  {
    if (itemizedText.text != String.Empty)
    {
     
      originalTotal = scanner.GetComponentInChildren<ScannerColliderScriptVRV2>().newTotal;
      okButton.SetActive(false);
      creditButton.SetActive(true);
      cashButton.SetActive(true);

      audioSource2.PlayOneShot(clip3);
    }
    else
    {
      mainText.text = "No Items";
      StartCoroutine("RemoveMainText");
    }
 

 
  }
  public void OnClickCash()
  {
    
    isCash = true;
    creditButton.SetActive(false);


  }

  public void OnClickCredit()
  {
   
    isCredit = true;
    cashButton.SetActive(false);
    cardSwipe.SetActive(true);
    cardInsert.SetActive(true);

    audioSource2.PlayOneShot(clip4);

  }

  public void Reset()
  {

    mainText.text = String.Empty;
    itemizedText.text = String.Empty;
    changeText.text = String.Empty;
    audioSource2.PlayOneShot(clip7);
    okButton.SetActive(true);
    creditButton.SetActive(false);
    cashButton.SetActive(false);
    cardSwipe.SetActive(false);
    cardInsert.SetActive(false);
  }



}
