using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TankController : MonoBehaviour
{
    Transform TankTransform;
    
    public float ThisTankDriveSpeed;
    public float ThisTankSpinSpeed;

    public bool MoveForward;
    public bool MoveBackward;
    public bool MoveLeft;
    public bool MoveRight;
    public bool SpinLeft;
    public bool SpinRight;
    public GameObject TankCameraHolder;

    private Rigidbody rb;
    public Vector3 SpinTankValue;
    private PhotonView view;


    void Start()
    {
        TankTransform = gameObject.transform;
        ThisTankDriveSpeed = MyGameManager.Instance.TankDriveSpeed;
        ThisTankSpinSpeed = MyGameManager.Instance.TankSpinSpeed;
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
        {
            TankCameraHolder.SetActive(false);
        }
    }

   


    private void Update()
    {
        if (!view.IsMine)
        {
            return;
        }

        if (MoveRight)
        {
            TankTransform.position -= ThisTankDriveSpeed * transform.right;
        }

        if (MoveLeft)
        {
            TankTransform.position += ThisTankDriveSpeed *  transform.right;
        }

        if (MoveBackward)
        {
            TankTransform.position -= ThisTankDriveSpeed * transform.up;
        }

        if (MoveForward)
        {
            TankTransform.position += ThisTankDriveSpeed * transform.up;
        }
    }





    private void FixedUpdate()
    {
        if (!view.IsMine)
        {
            return;
        }


        if (SpinLeft)
        {
            SpinTankValue = transform.forward * ThisTankSpinSpeed * -1;
            rb.AddTorque(SpinTankValue);
        }

        if (SpinRight)
        {
            SpinTankValue = transform.forward * ThisTankSpinSpeed;
            rb.AddTorque(SpinTankValue);
        }

    }



    //     movementVector.z = movementVector.z - KeyboardMultiplier;




}
