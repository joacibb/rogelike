using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : View

{ 
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _settingsButton;


    public override void Initialize()
    {
        _backButton.onClick.AddListener(ViewManagerPause.ShowLast);
        _settingsButton.onClick.AddListener(() => ViewManagerPause.Show<CreditsMenuView>());
    }
}
