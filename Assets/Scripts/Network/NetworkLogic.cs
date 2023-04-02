using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class NetworkLogic : MonoBehaviourPunCallbacks
{
    public static NetworkLogic instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connection Sucess");
    }
}
