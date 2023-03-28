using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MyGameManager : MonoBehaviour
{


    public GameObject TankModel;
    GameObject Player1tank;
    public TankController TankA, TankB, TankC, TankD;
    public List<TankController> ActiveTanks = new List<TankController>();
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
        //view = GetComponent<PhotonView>();
       // if (view.IsMine)
        //{
            GameBegin();
       // }
    }




    void GameBegin()
    {
        Transform TankASpawnPoint = TankSpawnPoints[0];

        //   GameObject TankAObject = PhotonNetwork.Instantiate(TankModel, TankASpawnPoint) as gameObject


        Vector3 loadRotation = new Vector3(-90, 0, 0);
        GameObject TankAObject = PhotonNetwork.Instantiate(TankModel.name, TankASpawnPoint.transform.position, Quaternion.Euler(loadRotation));
        TankAObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        TankController thisTank = TankAObject.GetComponent<TankController>();

        ActiveTanks.Add(thisTank);

        
        /*
        if (ActiveTanks.IndexOf(thisTank) == 0)
        {
            TankA = thisTank;
        }

        if (ActiveTanks.IndexOf(thisTank) == 1)
        {
            TankB = thisTank;
        }

        if (ActiveTanks.IndexOf(thisTank) == 2)
        {
            TankC = thisTank;
        }

        if (ActiveTanks.IndexOf(thisTank) == 3)
        {
            TankD = thisTank;
        }
        */

        TankA = TankAObject.GetComponent<TankController>();
    }


}
