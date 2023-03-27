using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    Transform TankTransform;
    public enum TankMovingDirection { NA, Forward, Backward, Left, Right };
    public TankMovingDirection tankMovingDirection;
    public float ThisTankDriveSpeed;
    public float ThisTankSpinSpeed;

    public bool MoveForward;
    public bool MoveBackward;
    public bool MoveLeft;
    public bool MoveRight;
    public bool SpinLeft;
    public bool SpinRight;

    Rigidbody rb;
    public Vector3 SpinTankValue;



    void Start()
    {
        TankTransform = gameObject.transform;
        ThisTankDriveSpeed = MyGameManager.Instance.TankDriveSpeed;
        ThisTankSpinSpeed = MyGameManager.Instance.TankSpinSpeed;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void fUpdate()
    {
       // return;
        
        float newXpos = TankTransform.position.x;
        float newYpos = TankTransform.position.y;
        float newZpos = TankTransform.position.z;


        switch (tankMovingDirection)
        {
            case TankMovingDirection.NA:
                break;
            case TankMovingDirection.Forward:
                newZpos =
             TankTransform.position.z + ThisTankDriveSpeed*-1;

                break;
            case TankMovingDirection.Backward:
                newZpos =
         TankTransform.position.z + ThisTankDriveSpeed;
                break;
            case TankMovingDirection.Left:
                newXpos =
               TankTransform.position.x + ThisTankDriveSpeed;
                break;
            case TankMovingDirection.Right:
                newXpos =
              TankTransform.position.x + ThisTankDriveSpeed * -1;
                break;
            default:
                break;
        }

        //TankTransform.localPosition = new Vector3(newXpos, newYpos, newZpos);
        TankTransform.position = new Vector3(newXpos, newYpos, newZpos);


    }

    void Update()
    {

        float newXpos = TankTransform.position.x;
        float newYpos = TankTransform.position.y;
        float newZpos = TankTransform.position.z;

        float spinAngleX = TankTransform.rotation.x;
        float spinAngleY = TankTransform.rotation.y;
        float spinAngleZ = TankTransform.rotation.z;

        if (MoveBackward)
        {
            newZpos =
             TankTransform.position.z + ThisTankDriveSpeed;
        }

        if (MoveForward)
        {
            newZpos =
            TankTransform.position.z + ThisTankDriveSpeed * -1;
        }

        if (MoveLeft)
        {
            newXpos =
          TankTransform.position.x + ThisTankDriveSpeed;
        }

        if (MoveRight)
        {
            newXpos =
       TankTransform.position.x + ThisTankDriveSpeed * -1;
        }

        TankTransform.position = new Vector3(newXpos, newYpos, newZpos);

    }

    private void FixedUpdate()
    {
        if (SpinLeft)
        {
            SpinTankValue = transform.forward * ThisTankSpinSpeed * -1;
            //  rb.AddTorque(transform.forward * ThisTankSpinSpeed * -1);
            rb.AddTorque(SpinTankValue);

        }

        if (SpinRight)
        {
            SpinTankValue = transform.forward * ThisTankSpinSpeed;
            //  rb.AddTorque(transform.forward * ThisTankSpinSpeed);
            rb.AddTorque(SpinTankValue);

        }

    }



    //     movementVector.z = movementVector.z - KeyboardMultiplier;




}
