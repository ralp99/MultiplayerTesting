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


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameBegin();
    }




    void GameBegin()
    {
        Transform TankASpawnPoint = TankSpawnPoints[0];

        //   GameObject TankAObject = PhotonNetwork.Instantiate(TankModel, TankASpawnPoint) as gameObject
        GameObject TankAObject = PhotonNetwork.Instantiate(TankModel.name, TankASpawnPoint.transform.position, Quaternion.identity);

        TankA = TankAObject.GetComponent<TankController>();
    }


}
