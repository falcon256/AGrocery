using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Text;
using System;

public class DifficultyChooseVR : MonoBehaviour
{
  public GameObject player;

  public GameObject difficultyMenuCanvas;

  public GameObject mainScreenCanvas;

  public GameObject eventSystem;

  public GameObject easyDifficultyButton;

  public GameObject product;

  public GameObject[] products;

  public List<GameObject> allProducts;

  public GameObject currentProduct;

  public string currentProductName;

  public int count = 0;

  public int productIndex;

  public GameObject shoppingList;
  public GameObject shoppingListTextObject;
  public TextMeshProUGUI shoppingListText;

  public StringBuilder listText;

  public bool noDifficultyChosen;

  public bool easyDifficulty = false;

  public bool normalDifficulty = false;

  public bool hardDifficulty = false;

  public bool showShoppingList;

  public bool gameIsActive;


  //public GameObject moneySpawnButton;
  private void Awake()
  {
    shoppingList = GameObject.FindWithTag("ShoppingList");
    shoppingListTextObject = GameObject.FindWithTag("shoppingListText");
    shoppingListText = shoppingListTextObject.GetComponent<TMPro.TextMeshProUGUI>();
  }

  void Start()
  {
    player = GameObject.FindWithTag("Player");

    difficultyMenuCanvas = GameObject.FindWithTag("DifficultyMenuCanvas");

    eventSystem = GameObject.FindWithTag("EventSystem");
    easyDifficultyButton = GameObject.FindWithTag("EasyModeButton");

    if (showShoppingList == false)
      shoppingList.SetActive(false);

    //product = productManager.GetComponent<ProductManager>().product;
    //products = productManager.GetComponent<ProductManager>().products;

    //shoppingListTextObject = GameObject.FindWithTag("shoppingListText");
    //shoppingListText = shoppingListTextObject.GetComponent<TMPro.TextMeshProUGUI>();
    


    listText = new StringBuilder();

    //Time.timeScale = 0;

    noDifficultyChosen = true;
  }

  private void FixedUpdate()
  {
   
  
     ToggleShoppingList();
    
    

  }

  private void ToggleShoppingList()
  {
    if (showShoppingList)
    {

      shoppingList.SetActive(true);


    }
    else
    {

      shoppingList.SetActive(false);

    }
  }

  void Update()
  {

   
   

    if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true && noDifficultyChosen == true)
    {
      eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(easyDifficultyButton);
     
    
    }


    if (OVRInput.GetDown(OVRInput.RawButton.B))
    {
      
       showShoppingList = !showShoppingList;
      
     
    
    }


    if (easyDifficulty)
    {
    
      
      while (count < 3)
      {
        count++;
        var objectsToFind = UnityEngine.Random.Range(0, products.Length);

        product = GameObject.FindGameObjectWithTag("Product");
        products = GameObject.FindGameObjectsWithTag("Product");
        productIndex = UnityEngine.Random.Range(0, products.Length);
        currentProduct = products[productIndex];
        Debug.Log(currentProduct.name);

        //currentProduct.GetComponent<Light>().enabled = true;

        listText.Append(currentProduct.name.Replace("(Clone)", " ").ToString() + " \n");
        shoppingListText.text = listText.ToString();
     
     





      }
      closeDifficultyMenu();
    }
    if (normalDifficulty)
    {
     
      while (count < 6)
      {
      
        count++;
        var objectsToFind = UnityEngine.Random.Range(0, products.Length);

        product = GameObject.FindGameObjectWithTag("Product");
        products = GameObject.FindGameObjectsWithTag("Product");
        productIndex = UnityEngine.Random.Range(0, products.Length);
        currentProduct = products[productIndex];
        Debug.Log(currentProduct.name);

        //currentProduct.GetComponent<Light>().enabled = true;

        listText.Append(currentProduct.name.Replace("(Clone)", " ").ToString() + " \n");
        shoppingListText.text = listText.ToString();
   
    

      }
      closeDifficultyMenu();
    }

    if (hardDifficulty)
    {
      
      while (count < 9)
      {
        count++;
        var objectsToFind = UnityEngine.Random.Range(0, products.Length);

        product = GameObject.FindGameObjectWithTag("Product");
        products = GameObject.FindGameObjectsWithTag("Product");
        productIndex = UnityEngine.Random.Range(0, products.Length);
        currentProduct = products[productIndex];

        //currentProduct.GetComponent<Light>().enabled = true;

        listText.Append(currentProduct.name.Replace("(Clone)", " ").ToString() + " \n");
        shoppingListText.text = listText.ToString();
       
   

      }
      closeDifficultyMenu();
    }
  }

 

  public void resetDifficulty()
  {
    easyDifficulty = false;
    normalDifficulty = false;
    hardDifficulty = false;
  }

  public void SetEasyDifficulty()
  {
    resetDifficulty();
    easyDifficulty = true;
  }

  public void SetNormalDifficulty()
  {
    resetDifficulty();
    normalDifficulty = true;
  }

  public void SetHardDifficulty()
  {
    resetDifficulty();
    hardDifficulty = true;
  }

  public void closeDifficultyMenu()
  {
    //Time.timeScale = 1;
    difficultyMenuCanvas.SetActive(false);
    noDifficultyChosen = false;
    SetNormalDifficulty();
  }
  public void closeDifficultyMenu2()
  {
    //Time.timeScale = 1;
   
    difficultyMenuCanvas.SetActive(false);
    noDifficultyChosen = false;
    SetNormalDifficulty();
  }
}
