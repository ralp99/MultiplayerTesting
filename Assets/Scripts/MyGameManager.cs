using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }


    void GameBegin()
    {
        Transform TankASpawnPoint = TankSpawnPoints[0];

        GameObject TankAObject = Instantiate(TankModel, TankASpawnPoint);
        TankA = TankAObject.GetComponent<TankController>();
    }


}
