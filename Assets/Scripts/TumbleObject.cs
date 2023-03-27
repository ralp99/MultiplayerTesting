using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleObject : MonoBehaviour
{
    [HideInInspector]
    public bool isDragging = false;
    private Camera CameraMain;
    public float horzTolerance = 0.3f;
    public float vertTolerance = 0.15f;
    public float RotSpeed = 1.0f;

    float horzToleranceNeg;
    float vertToleranceNeg;

    [HideInInspector]
    public Vector3 initState;

    private MainController mainController;


    [Space]
    public float watchingVal;

    public  bool vertFlip;
    bool horizFlip;


    void Start()
    {
        CameraMain = Camera.main;
        horzToleranceNeg = -1 * horzTolerance;
        vertToleranceNeg = -1 * vertTolerance;
        initState = transform.localEulerAngles;
        mainController = FindObjectOfType<MainController>();
    }


    void Update()
    {

        isDragging = Input.GetMouseButton(0);
        

        if (!isDragging)
        {
            return;
        }

        /*
        Ray myRay = CameraMain.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        */

        if (Input.GetAxis("Mouse X") > horzTolerance)
        {
            SpinObject(true, true);
        }

        if (Input.GetAxis("Mouse X") < horzToleranceNeg)
        {
            SpinObject(false, true);
        }

        if (Input.GetAxis("Mouse Y") > vertTolerance)
        {
            SpinObject(true, false);
        }

        if (Input.GetAxis("Mouse Y") < vertToleranceNeg)
        {
            SpinObject(false, false);  
        }

    }


    /*
    void CheckFlips()
    {
        vertFlip = false;
        horizFlip = false;

        float angle = transform.localEulerAngles.z;

       // angle = (angle > 180) ? angle - 360 : angle;


        if (angle > 180)
        {
            angle = angle - 360;
        }

        watchingVal = angle;


        if (watchingVal < 0)
        {
            vertFlip = true;
        }

    }
    */



    void SpinObject(bool positive, bool horiz)
    {
        float useRotspeed = RotSpeed;

        if (positive)
        {
            useRotspeed = useRotspeed * -1;
        }

        //Vector3 newOutputAngles = new Vector3();


        if (horiz)
        {
                transform.localEulerAngles += new Vector3(0f, useRotspeed, 0f);
        //    newOutputAngles = new Vector3(0f, useRotspeed, 0f);
        }
        else
        {
            /*
            if (vertFlip)
            {
              //  useRotspeed = useRotspeed * -1;
            }
            */

            useRotspeed = useRotspeed * -1;
             transform.localEulerAngles += new Vector3(0f, 0f, useRotspeed);
         //   newOutputAngles = new Vector3(0f, 0f, useRotspeed);

        }


          mainController.TumbleSelectedObject(transform.localEulerAngles);
        //  mainController.TumbleSelectedObject(newOutputAngles);

    }


}
