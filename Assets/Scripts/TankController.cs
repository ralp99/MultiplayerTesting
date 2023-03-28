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

    Rigidbody rb;
    public Vector3 SpinTankValue;



    void Start()
    {
        TankTransform = gameObject.transform;
        ThisTankDriveSpeed = MyGameManager.Instance.TankDriveSpeed;
        ThisTankSpinSpeed = MyGameManager.Instance.TankSpinSpeed;
        rb = GetComponent<Rigidbody>();
    }

   

    void Update()
    {

        float newXpos = TankTransform.localPosition.x;
        float newYpos = TankTransform.localPosition.y;
        float newZpos = TankTransform.localPosition.z;

        float spinAngleX = TankTransform.rotation.x;
        float spinAngleY = TankTransform.rotation.y;
        float spinAngleZ = TankTransform.rotation.z;


        if (MoveBackward)
        {
            newZpos =
             TankTransform.localPosition.z + ThisTankDriveSpeed;
        }

        if (MoveForward)
        {
            newZpos =
            TankTransform.localPosition.z + ThisTankDriveSpeed * -1;
        }

        if (MoveLeft)
        {
            newXpos =
          TankTransform.localPosition.x + ThisTankDriveSpeed;
        }

        if (MoveRight)
        {
            newXpos =
       TankTransform.localPosition.x + ThisTankDriveSpeed * -1;
        }

        TankTransform.localPosition = new Vector3(newXpos, newYpos, newZpos);

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
