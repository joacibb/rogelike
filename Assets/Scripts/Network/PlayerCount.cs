using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerCount : MonoBehaviourPunCallbacks
{
    public Text playerCountText;

    public override void OnJoinedRoom()
    {
        // Actualiza el texto con la cantidad actual de jugadores
        playerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // Actualiza el texto con la cantidad actual de jugadores
        playerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // Actualiza el texto con la cantidad actual de jugadores
        playerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers;
    }
}