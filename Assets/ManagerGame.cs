using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviourPunCallbacks
{
    public Text winText;

    private bool gameOver;

    private void Start()
    {
        gameOver = false;
    }

    [PunRPC]
    public void PlayerWon(string playerName)
    {
        if (!gameOver)
        {
            gameOver = true;
            winText.text = $"{playerName} ha ganado el juego!";
        }
    }
}