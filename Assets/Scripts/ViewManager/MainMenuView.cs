using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creditsButton;

    public override void Initialize()
    {
        _startButton.onClick.AddListener(StartGame);
        _creditsButton.onClick.AddListener(() => ViewManager.Show<CreditsMenuView>());
    }

    private static void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}