using Photon.Pun;
using UnityEngine;

public class MapManager : MonoBehaviourPunCallbacks
{
    public GameObject mapPrefab;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(mapPrefab.name, Vector3.zero, Quaternion.identity);
        }
    }
}
