using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{

    public Transform FollowingTransform;
    TankController tankController;

    public bool LockPosX, LockPosY, LockPosZ;
    public bool LockRotX, LockRotY, LockRotZ;
    float newXpos, newYpos, newZpos;
    float newXrot, newYrot, newZrot;

    public float offsetPosX, offsetPosY, offsetPosZ;
    public float offsetRotX, offsetRotY, offsetRotZ;

    public bool CaptureInitPosOffset;
    public bool CaptureInitRotOffset;
    public bool CaptureSpinTankValueForRot;

   public Vector3 tankControllerSpinValues;

    void Start()
    {
        offsetPosX = 0f;
        offsetPosY = 0f;
        offsetPosZ = 0f;

        offsetRotX = 0f;
        offsetRotY = 0f;
        offsetRotZ = 0f;

        if (CaptureInitPosOffset)
        {
            offsetPosX = transform.position.x;
            offsetPosY = transform.position.y;
            offsetPosZ = transform.position.z;
        }

        if (CaptureInitRotOffset)
        {
            offsetRotX = transform.eulerAngles.x;
            offsetRotY = transform.eulerAngles.y;
            offsetRotZ = transform.eulerAngles.z;
        }

        tankController = FollowingTransform.GetComponent<TankController>();
        transform.SetParent(null, true);



    }

    // Update is called once per frame
    void Update()
    {
        newXpos = transform.position.x;
        newYpos = transform.position.y;
        newZpos = transform.position.z;

        newXrot = transform.eulerAngles.x;
        newYrot = transform.eulerAngles.y;
        newZrot = transform.eulerAngles.z;


        if (LockPosX)
        {
            newXpos = FollowingTransform.position.x + offsetPosX;
        }

        if (LockPosY)
        {
            newYpos = FollowingTransform.position.y + offsetPosY;
        }

        if (LockPosZ)
        {
            newZpos = FollowingTransform.position.z + offsetPosZ;
        }

        transform.position = new Vector3(newXpos, newYpos, newZpos);



        if (CaptureSpinTankValueForRot)
        {
            tankControllerSpinValues = tankController.SpinTankValue;

            if (LockRotX)
            {
                newXrot = tankControllerSpinValues.x + offsetRotX;
            }

            if (LockRotY)
            {
                newYrot = tankControllerSpinValues.y + offsetRotY;
            }

            if (LockRotZ)
            {
                newZrot = tankControllerSpinValues.z + offsetRotZ;
            }
        }

        else
        {
            if (LockRotX)
            {
                newXrot = FollowingTransform.eulerAngles.x + offsetRotX;
            }

            if (LockRotY)
            {
                newYrot = FollowingTransform.eulerAngles.y + offsetRotY;
            }

            if (LockRotZ)
            {
                newZrot = FollowingTransform.eulerAngles.z + offsetRotZ;
            }
        }

        transform.eulerAngles = new Vector3(newXrot, newYrot, newZrot);

    }
}
