using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        //SceneManager.LoadScene("Game");
        PhotonNetwork.JoinRandomOrCreateRoom();
        //PhotonNetwork.CreateRoom("a");
        //PhotonNetwork.JoinRoom("test");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom);
        Debug.Log(PhotonNetwork.InRoom);
        PhotonNetwork.LoadLevel("Game");
    }
}
