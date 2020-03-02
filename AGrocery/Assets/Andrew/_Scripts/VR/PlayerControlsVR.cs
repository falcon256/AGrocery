using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControlsVR : MonoBehaviour
{
    public GameObject player;

    public GameObject GameMenuCanvas;

    public GameObject eventSystem;

    public GameObject gameSettingsButton;


    //public GameObject moneySpawnButton;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        GameMenuCanvas = GameObject.FindWithTag("GameMenuCanvas");

        eventSystem = GameObject.FindWithTag("EventSystem");
        gameSettingsButton = GameObject.FindWithTag("GameSettingsButton");
        //moneySpawnButton = GameObject.FindWithTag("MoneySpawnButton");
    }

    void Update()
    {
        if (Input.GetButtonDown("Oculus_CrossPlatform_Button4"))
        {
            GameMenuCanvas.GetComponent<Canvas>().enabled = true;
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(gameSettingsButton);
        }

        if (Input.GetButtonDown("Oculus_CrossPlatform_Button2"))
        {
            //eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(moneySpawnButton);
        }
    }
}
