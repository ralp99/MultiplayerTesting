using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Rigidbody rb;
    public Vector3 SpinTankValue;



    void Start()
    {
        TankTransform = gameObject.transform;
        ThisTankDriveSpeed = MyGameManager.Instance.TankDriveSpeed;
        ThisTankSpinSpeed = MyGameManager.Instance.TankSpinSpeed;
        rb = GetComponent<Rigidbody>();
    }

   


    private void Update()
    {

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
