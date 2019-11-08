using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject player;
    public GameObject GameMenuCanvas;
    public GameObject ItemMenuCanvas;
    public GameObject ControlsMenuCanvas;
    public GameObject ObjectivesMenuCanvas;
    public GameObject GameSettingsMenuCanvas;
    public GameObject VolumeSettingsMenuCanvas;
    public GameObject DeliMeatsMenuCanvas;
    public GameObject ProduceMenuCanvas;
    public GameObject DryGoodsMenuCanvas;
    public GameObject BeveragesMenuCanvas;
    public GameObject SnackFoodsMenuCanvas;
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
        ControlsMenuCanvas = GameObject.FindWithTag("ControlsMenuCanvas");
        ObjectivesMenuCanvas = GameObject.FindWithTag("ObjectivesMenuCanvas");
        GameSettingsMenuCanvas = GameObject.FindWithTag("GameSettingsCanvas");
        VolumeSettingsMenuCanvas = GameObject.FindWithTag("VolumeSettingsCanvas");
        DeliMeatsMenuCanvas = GameObject.FindWithTag("DeliMeatsMenuCanvas");
        ProduceMenuCanvas = GameObject.FindWithTag("ProduceMenuCanvas");
        DryGoodsMenuCanvas = GameObject.FindWithTag("DryGoodsMenuCanvas");
        BeveragesMenuCanvas = GameObject.FindWithTag("BeverageMenuCanvas");
        SnackFoodsMenuCanvas = GameObject.FindWithTag("SnackFoodsMenuCanvas");
        MusicSettingsMenuCanvas = GameObject.FindWithTag("MusicSettingsMenuCanvas");
        AmbientSettingsMenuCanvas = GameObject.FindWithTag("AmbientSettingsMenuCanvas");
        VoiceSettingsMenuCanvas = GameObject.FindWithTag("VoiceSettingsMenuCanvas");
        FootstepsSettingsMenuCanvas = GameObject.FindWithTag("FootstepsSettingsMenuCanvas");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameMenuCanvas.GetComponent<Canvas>().enabled = true;
            ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
            ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
            ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
            GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
            ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
            DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
            BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
            SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
            MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameMenuCanvas.GetComponent<Canvas>().enabled = false;
            ItemMenuCanvas.GetComponent<Canvas>().enabled = true;
            ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
            ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
            GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
            ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
            DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
            BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
            SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
            MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameMenuCanvas.GetComponent<Canvas>().enabled = false;
            ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
            ControlsMenuCanvas.GetComponent<Canvas>().enabled = true;
            ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
            GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
            ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
            DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
            BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
            SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
            MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameMenuCanvas.GetComponent<Canvas>().enabled = false;
            ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
            ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
            ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = true;
            GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
            ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
            DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
            BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
            SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
            MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
            FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToGame();
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
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowGameMenuCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = true;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowItemMenuCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = true;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowControlsMenuCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = true;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowObjectivesMenuCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = true;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowGameSettingsCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowVolumeSettingsCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowDeliMeatsMenuCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = true;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowProduceMenuCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = true;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowDryGoodsMenuCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = true;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowBeveragesMenuCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = true;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowSnackFoodsMenuCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = true;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowMusicSettingsCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowAmbientSettingsCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowVoiceSettingsCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ShowFootstepsSettingsCanvas()
    {
        GameMenuCanvas.GetComponent<Canvas>().enabled = false;
        ItemMenuCanvas.GetComponent<Canvas>().enabled = false;
        ControlsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ObjectivesMenuCanvas.GetComponent<Canvas>().enabled = false;
        GameSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VolumeSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        DeliMeatsMenuCanvas.GetComponent<Canvas>().enabled = false;
        ProduceMenuCanvas.GetComponent<Canvas>().enabled = false;
        DryGoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        BeveragesMenuCanvas.GetComponent<Canvas>().enabled = false;
        SnackFoodsMenuCanvas.GetComponent<Canvas>().enabled = false;
        MusicSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        AmbientSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        VoiceSettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
        FootstepsSettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void ActivateItem()
    {

    }


}
