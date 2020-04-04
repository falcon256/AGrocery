using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerVR : MonoBehaviour
{
  public GameObject player;
  public GameObject GameMenuCanvas;
  public GameObject ItemMenuCanvas;
  public GameObject FoodItemMenuCanvas;

  public GameObject ControlsMenuCanvas;
  public GameObject ObjectivesMenuCanvas;
  public GameObject GameSettingsMenuCanvas;
  public GameObject VolumeSettingsMenuCanvas;

  public GameObject DeliMeatsMenuCanvas;
  public GameObject ProduceMenuCanvas;
  public GameObject DryGoodsMenuCanvas;
  public GameObject BeveragesMenuCanvas;
  public GameObject SnackFoodsMenuCanvas;

  public GameObject HousewaresMenuCanvas;
  public GameObject ElectronicsMenuCanvas;
  public GameObject ToysMenuCanvas;
  public GameObject BathroomMenuCanvas;
  public GameObject OtherMenuCanvas;

  public GameObject MusicSettingsMenuCanvas;
  public GameObject AmbientSettingsMenuCanvas;
  public GameObject VoiceSettingsMenuCanvas;
  public GameObject FootstepsSettingsMenuCanvas;

  public bool mainCanvasMode;
  public bool firstPersonCanvasMode;
  public bool BEVCanvasMode;


  void Start()
  {
    player = GameObject.FindWithTag("Player");
    GameMenuCanvas = GameObject.FindWithTag("GameMenuCanvas");
    ItemMenuCanvas = GameObject.FindWithTag("ItemMenuCanvas");
    FoodItemMenuCanvas = GameObject.FindWithTag("FoodItemMenuCanvas");
    ControlsMenuCanvas = GameObject.FindWithTag("ControlsMenuCanvas");
    ObjectivesMenuCanvas = GameObject.FindWithTag("ObjectivesMenuCanvas");
    GameSettingsMenuCanvas = GameObject.FindWithTag("GameSettingsCanvas");
    VolumeSettingsMenuCanvas = GameObject.FindWithTag("VolumeSettingsCanvas");
    DeliMeatsMenuCanvas = GameObject.FindWithTag("DeliMeatsMenuCanvas");
    ProduceMenuCanvas = GameObject.FindWithTag("ProduceMenuCanvas");
    DryGoodsMenuCanvas = GameObject.FindWithTag("DryGoodsMenuCanvas");
    BeveragesMenuCanvas = GameObject.FindWithTag("BeverageMenuCanvas");
    SnackFoodsMenuCanvas = GameObject.FindWithTag("SnackFoodsMenuCanvas");

    HousewaresMenuCanvas = GameObject.FindWithTag("HousewaresMenuCanvas");
    ElectronicsMenuCanvas = GameObject.FindWithTag("ElectronicsMenuCanvas");
    ToysMenuCanvas = GameObject.FindWithTag("ToysMenuCanvas");
    BathroomMenuCanvas = GameObject.FindWithTag("BathroomMenuCanvas");
    OtherMenuCanvas = GameObject.FindWithTag("OtherMenuCanvas");

    MusicSettingsMenuCanvas = GameObject.FindWithTag("MusicSettingsMenuCanvas");
    AmbientSettingsMenuCanvas = GameObject.FindWithTag("AmbientSettingsMenuCanvas");
    VoiceSettingsMenuCanvas = GameObject.FindWithTag("VoiceSettingsMenuCanvas");
    FootstepsSettingsMenuCanvas = GameObject.FindWithTag("FootstepsSettingsMenuCanvas");
  }

  public void Update()
  {
    if (OVRInput.Get(OVRInput.Button.Start) == true)
    {
      if (GameMenuCanvas != null)
      {
        GameMenuCanvas.GetComponent<Canvas>().enabled = !GameMenuCanvas.GetComponent<Canvas>().enabled;

      }

    }
  }
  public void LoadByIndex(int sceneIndex)
  {
    SceneManager.LoadScene(sceneIndex);
  }

  public void ReturnToGame()
  {
    GameMenuCanvas.GetComponent<Canvas>().enabled = false;
    ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
    FoodItemMenuCanvas.GetComponent<Canvas>().enabled = false;
    ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
    ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
    GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
    ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
    DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
    BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
    SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;

    HousewaresMenuCanvas.GetComponent<Canvas>().enabled = false;
    ElectronicsMenuCanvas.GetComponent<Canvas>().enabled = false;
    ToysMenuCanvas.GetComponent<Canvas>().enabled = false;
    BathroomMenuCanvas.GetComponent<Canvas>().enabled = false;
    OtherMenuCanvas.GetComponent<Canvas>().enabled = false;

    MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    Time.timeScale = 1;
  }

  public void ShowGameMenuCanvas()
  {
    ReturnToGame();
    GameMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowItemMenuCanvas()
  {
    ReturnToGame();
    ItemMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowFoodItemMenuCanvas()
  {
    ReturnToGame();
    FoodItemMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowControlsMenuCanvas()
  {
    ReturnToGame();
    ControlsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowObjectivesMenuCanvas()
  {
    ReturnToGame();
    ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowGameSettingsCanvas()
  {
    ReturnToGame();
    GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowVolumeSettingsCanvas()
  {
    ReturnToGame();
    VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowDeliMeatsMenuCanvas()
  {
    ReturnToGame();
    DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowProduceMenuCanvas()
  {
    ReturnToGame();
    ProduceMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowDryGoodsMenuCanvas()
  {
    ReturnToGame();
    DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowBeveragesMenuCanvas()
  {
    ReturnToGame();
    BeveragesMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowSnackFoodsMenuCanvas()
  {
    ReturnToGame();
    SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  //

  public void ShowHousewaresMenuCanvas()
  {
    ReturnToGame();
    HousewaresMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowElectronicsMenuCanvas()
  {
    ReturnToGame();
    ElectronicsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowToysMenuCanvas()
  {
    ReturnToGame();
    ToysMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowBathroomMenuCanvas()
  {
    ReturnToGame();
    BathroomMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowOtherMenuCanvas()
  {
    ReturnToGame();
    OtherMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  //

  public void ShowMusicSettingsCanvas()
  {
    ReturnToGame();
    VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowAmbientSettingsCanvas()
  {
    ReturnToGame();
    VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowVoiceSettingsCanvas()
  {
    ReturnToGame();
    VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ShowFootstepsSettingsCanvas()
  {
    ReturnToGame();
    VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    Time.timeScale = 0;
  }

  public void ActivateItem()
  {

  }


}
