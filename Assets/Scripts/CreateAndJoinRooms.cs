using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

  //  public InputField CreateInput;
  //  public InputField JoinInput;

    public TMPro.TMP_InputField CreateInput;
    public TMPro.TMP_InputField JoinInput;
    //  public Object SceneToLoad;
    // public string SceneNameToLoad = "";

    public string[] SceneNameToLoad;
    public int LoadIndex = 0;



    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateInput.text);
        // creating a room, will automatically cause user to join that room
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinInput.text);
    }

    public override void OnJoinedRoom()
    {
        //   base.OnJoinedRoom();
        PhotonNetwork.LoadLevel(SceneNameToLoad[LoadIndex]);
    }

    public void CloseApp()
    {
        Application.Quit();
    }

}
