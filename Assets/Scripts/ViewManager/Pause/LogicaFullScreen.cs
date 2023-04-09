using System;
using UnityEngine;
using UnityEngine.UI;

public class LogicaFullScreen : MonoBehaviour
{
    public Toggle toggle;

    private void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    private void Update()
    {
        
    }

    public void activateFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
}