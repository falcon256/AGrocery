using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButton : MonoBehaviour
{
    public Image backgroundImg;
    public Color idleColor;
    public Color hoverColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGazeEnter()
    {
        backgroundImg.color = hoverColor;
    }

    public void OnGazeExit()
    {
        backgroundImg.color = idleColor;
    }
}
