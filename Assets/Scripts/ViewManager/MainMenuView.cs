using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _multiplayerButton;

    public override void Initialize()
    {
        _startButton.onClick.AddListener(StartGame);
        _creditsButton.onClick.AddListener(() => ViewManager.Show<CreditsMenuView>());
        _multiplayerButton.onClick.AddListener(LoadMultiplayer);
    }

    private static void LoadMultiplayer()
    {
        SceneManager.LoadScene("Loading");
    }
    private static void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}