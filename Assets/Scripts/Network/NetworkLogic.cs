using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkLogic : MonoBehaviourPunCallbacks
{
    public static NetworkLogic instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            DontDestroyOnLoad(gameObject);
            // Si ya hay una instancia de NetworkLogic en la escena, destruye esta instancia
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Conecta al servidor de Photon
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon");
    }
}