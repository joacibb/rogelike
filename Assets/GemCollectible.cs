using Photon.Pun;
using UnityEngine;

public class GemCollectible : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            photonView.RPC("PlayerWon", RpcTarget.All, other.GetComponent<PhotonView>().Owner.NickName);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}