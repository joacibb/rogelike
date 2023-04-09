using System;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject playerPrefab;
    
    private void Start()
    {
        int playerNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        Vector2 spawnPosition = spawnPoints[playerNumber - 1].transform.position;
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
    }
}