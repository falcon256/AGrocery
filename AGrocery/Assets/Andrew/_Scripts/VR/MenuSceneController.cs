using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneController : MonoBehaviour
{
  public GameObject startMenuCanvas;
  public GameObject levelSelectCanvas;
  public GameObject tutorialMenuCanvas;
  public GameObject controlMenuCanvas
    ;
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

  public void ShowLevelCanvas()
  {
    startMenuCanvas.SetActive(false);
    levelSelectCanvas.SetActive(true);
    tutorialMenuCanvas.SetActive(false);
    controlMenuCanvas.SetActive(false);
  }


  public void ShowTutorialCanvas()
  {
    startMenuCanvas.SetActive(false);
    levelSelectCanvas.SetActive(false);
    tutorialMenuCanvas.SetActive(true);
    controlMenuCanvas.SetActive(false);
  }


  public void ShowControlCanvas()
  {
    startMenuCanvas.SetActive(false);
    levelSelectCanvas.SetActive(false);
    tutorialMenuCanvas.SetActive(false);
    controlMenuCanvas.SetActive(true);
  }
}
