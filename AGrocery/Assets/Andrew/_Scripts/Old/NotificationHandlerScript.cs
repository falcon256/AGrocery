using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationHandlerScript : MonoBehaviour
{
    public GameObject player;

    public GameObject thoughtBubbleCanvas;

    public GameObject thoughtBubbleTextBox;
    public Text thoughtBubbleText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        thoughtBubbleCanvas = GameObject.FindWithTag("ThoughtBubbleCanvas");
        thoughtBubbleTextBox = GameObject.FindWithTag("ThoughtBubbleText");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "ShopperMan")
        {
            ShopperManDialogueChoose();
            thoughtBubbleCanvas.GetComponent<Canvas>().enabled = true;
            
        }
        if (Player.gameObject.tag == "ShopperWoman")
        {
            ShopperWomanDialogueChoose();
            thoughtBubbleCanvas.GetComponent<Canvas>().enabled = true;
            
        }
        
        if (Player.gameObject.tag == "Employee")
        {
            EmployeeDialogueChoose();
            thoughtBubbleCanvas.GetComponent<Canvas>().enabled = true;
        }
        if (Player.gameObject.tag == "Cashier")
        {
            CashierDialogueChoose();
            thoughtBubbleCanvas.GetComponent<Canvas>().enabled = true;
        }
    }

    void OnTriggerStay(Collider Player)
    {

        if (Player.gameObject.tag == "ShopperMan" && Input.GetKeyDown(KeyCode.E))
        {
            ShopperManDialogueChoose();
        }
        if (Player.gameObject.tag == "ShopperWoman" && Input.GetKeyDown(KeyCode.E))
        {
            ShopperWomanDialogueChoose();
        }
        if (Player.gameObject.tag == "Employee" && Input.GetKeyDown(KeyCode.E))
        {
            EmployeeDialogueChoose();
        }
        if (Player.gameObject.tag == "Cashier" && Input.GetKeyDown(KeyCode.E))
        {
            CashierDialogueChoose();
        }
    }
    void OnTriggerExit(Collider Player)
    {
        thoughtBubbleCanvas.GetComponent<Canvas>().enabled = false;
    }

    void ShopperManDialogueChoose()
    {
        var dialogueOptionToSay = Random.Range(0, 3);

        if (dialogueOptionToSay == 0)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Man: Hello!";
        }
        else if (dialogueOptionToSay == 1)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Man: Uh... Hi.";
        }
        else if (dialogueOptionToSay == 2)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Man: Hmm...";
        }
    }
    void ShopperWomanDialogueChoose()
    {
        var dialogueOptionToSay = Random.Range(0, 3);

        if (dialogueOptionToSay == 0)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Woman: Hello There!";
        }
        else if (dialogueOptionToSay == 1)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Woman: Hi.";
        }
        else if (dialogueOptionToSay == 2)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Woman: Hmm...";
        }
    }

    void EmployeeDialogueChoose()
    {
        var dialogueOptionToSay = Random.Range(0, 3);

        if (dialogueOptionToSay == 0)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Employee: See anything you like?";
        }
        else if (dialogueOptionToSay == 1)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Employee: Need any help?";
        }
        else if (dialogueOptionToSay == 2)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Employee: Welcome to AGrocery Store!";
        }
    }
    void CashierDialogueChoose()
    {
        var dialogueOptionToSay = Random.Range(0, 3);

        if (dialogueOptionToSay == 0)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Cashier: Pay for things here.";
        }
        else if (dialogueOptionToSay == 1)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Cashier: Give me the money and there won't be a problem.";
        }
        else if (dialogueOptionToSay == 2)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = "Cashier: Did you find everything okay?";
        }
    }
}
