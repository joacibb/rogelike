using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MapManagerView : MonoBehaviour
{
    
     public GameObject[] rooms;

     private void OnEnable()
     {
         PhotonNetwork.AddCallbackTarget(this);
     }

     private void OnDisable()
     {
         PhotonNetwork.RemoveCallbackTarget(this);
     }

     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
     {
         if (stream.IsWriting)
         {
             // Envía el estado actual del mapa a todos los demás jugadores.
             stream.SendNext(rooms);
         }
         else
         {
             // Recibe el estado del mapa de otro jugador y lo actualiza localmente.
             rooms = (GameObject[])stream.ReceiveNext();
         }
     }

}
