using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;
    public byte maxPlayers = 4; // La cantidad máxima de jugadores en la sala
    public int minPlayers = 2; // La cantidad mínima de jugadores necesaria para iniciar el juego
    public GameObject startButton; // El botón que inicia el juego
    public Text waitingText; // El mensaje que se muestra cuando se espera a los jugadores
    private bool gameStarted = false; // El estado del juego

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions { MaxPlayers = maxPlayers });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount < maxPlayers) // Verifica si hay espacio para unirse a la sala
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount >=
                minPlayers) // Verifica si hay suficientes jugadores para iniciar el juego
            {
                // Muestra el botón de inicio del juego
                startButton.SetActive(true);
                waitingText.gameObject.SetActive(false);
            }
            else
            {
                // Muestra el mensaje de espera a los jugadores
                waitingText.text = "Esperando jugadores...";
                waitingText.gameObject.SetActive(true);
            }
        }
        else
        {
            // La sala está llena, no se puede unir
            Debug.Log("La sala está llena, no se puede unir");
        }
    }

    public void StartGame()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= minPlayers)
        {
            // Impide que los jugadores se unan a la sala
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;

            // Carga la escena del juego
            PhotonNetwork.LoadLevel("Game");
        }
    }

}