using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MyGameManager : MonoBehaviour
{


    public GameObject TankModel;
    GameObject Player1tank;
    public TankController TankA, TankB, TankC;
    public Transform[] TankSpawnPoints;
    public float TankDriveSpeed = 1.0f;
    public float TankSpinSpeed = 1.0f;
    public static MyGameManager Instance;
    private PhotonView view;



    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            GameBegin();
        }
    }




    void GameBegin()
    {
        Transform TankASpawnPoint = TankSpawnPoints[0];

        //   GameObject TankAObject = PhotonNetwork.Instantiate(TankModel, TankASpawnPoint) as gameObject


        Vector3 loadRotation = new Vector3(-90, 0, 0);
        GameObject TankAObject = PhotonNetwork.Instantiate(TankModel.name, TankASpawnPoint.transform.position, Quaternion.Euler(loadRotation));

        TankA = TankAObject.GetComponent<TankController>();
        TankAObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }


}
