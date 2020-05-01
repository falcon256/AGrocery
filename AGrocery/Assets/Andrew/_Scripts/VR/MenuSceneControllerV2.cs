using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneControllerV2 : MonoBehaviour
{
  public GameObject startMenuCanvas;
  public GameObject levelSelectCanvas;
  public GameObject tutorialMenuCanvas;
  public GameObject controlMenuCanvas;
  public GameObject itemHuntTutorialCanvas;
  public GameObject askForHelpTutorialCanvas;
  public GameObject employeeCheckoutTutorialCanvas;
  public GameObject selfCheckoutTutorialCanvas;
  void Start()
  {

        //startMenuCanvas = GameObject.FindGameObjectWithTag("StartMenuCanvas");
        //levelSelectCanvas = GameObject.FindGameObjectWithTag("LevelSelectCanvas");
        //tutorialMenuCanvas = GameObject.FindGameObjectWithTag("TutorialMenuCanvas");
        //controlMenuCanvas = GameObject.FindGameObjectWithTag("ControlMenuCanvas");


        //startMenuCanvas.SetActive(true);
        //levelSelectCanvas.SetActive(false);
        //tutorialMenuCanvas.SetActive(false);
        //controlMenuCanvas.SetActive(false);

    }

    public void hideMenus()
    {
        startMenuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(false);
        tutorialMenuCanvas.SetActive(false);
        controlMenuCanvas.SetActive(false);
        itemHuntTutorialCanvas.SetActive(false);
        askForHelpTutorialCanvas.SetActive(false);
        employeeCheckoutTutorialCanvas.SetActive(false);
        selfCheckoutTutorialCanvas.SetActive(false);
    }

  public void ShowLevelCanvas()
  {
        hideMenus();
        levelSelectCanvas.SetActive(true);
  }


  public void ShowTutorialCanvas()
  {
        hideMenus();
        tutorialMenuCanvas.SetActive(true);
  }


  public void ShowControlCanvas()
  {
        hideMenus();
        controlMenuCanvas.SetActive(true);
  }

    public void ShowItemHuntTutorialCanvas()
    {
        hideMenus();
        itemHuntTutorialCanvas.SetActive(true);
    }


    public void ShowAskForHelpTutorialCanvas()
    {
        hideMenus();
        askForHelpTutorialCanvas.SetActive(true);
    }


    public void ShowEmployeeCheckoutTutorialCanvas()
    {
        hideMenus();
        employeeCheckoutTutorialCanvas.SetActive(true);
    }

    public void ShowSelfCheckoutTutorialCanvas()
    {
        hideMenus();
        selfCheckoutTutorialCanvas.SetActive(true);
    }

}
