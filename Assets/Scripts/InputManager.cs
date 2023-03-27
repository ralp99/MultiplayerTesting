using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public string UpButton;
    public string DownButton;
    public string LeftButton;
    public string RightButton;
    public string SpinLeftButton;
    public string SpinRightButton;

    public string FireButton;

    public bool MovingForward;
    public bool MovingBackward;
    public bool MovingLeft;
    public bool MovingRight;
    public bool SpinLeft;
    public bool SpinRight;
    public bool Firing;

    //public bool coolingDown;
    bool coolingDown;
    public float FireCooldown = 0.75f;
    TankController TankActl;
    MyGameManager myGameManager;

    private void Awake()
    {
    }

    void Start()
    {
        myGameManager = MyGameManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {

        if (!TankActl)
        {
            if (myGameManager)
            {
                TankActl = myGameManager.TankA;
            }
        }

        if (!TankActl)
        {
            return;
        }


        MovingForward = Input.GetKey(UpButton);
        MovingBackward = Input.GetKey(DownButton);
        MovingLeft = Input.GetKey(LeftButton);
        MovingRight = Input.GetKey(RightButton);
        SpinLeft = Input.GetKey(SpinLeftButton);
        SpinRight = Input.GetKey(SpinRightButton);

        if (Input.GetKey(KeyCode.Space))
        {
            TryFire();
        }

        TankActl.MoveBackward = MovingBackward;
        TankActl.MoveForward = MovingForward;
        TankActl.MoveLeft = MovingLeft;
        TankActl.MoveRight = MovingRight;
        TankActl.SpinLeft = SpinLeft;
        TankActl.SpinRight = SpinRight;



    }




    void TryFire()
    {
        if (coolingDown)
        {
            return;
        }
        coolingDown = true;
        Firing = true;
        StartCoroutine(FireTimer());
    }

    IEnumerator FireTimer()
    {
        Firing = false;
        yield return new WaitForSeconds(FireCooldown);
        coolingDown = false;
    }

}
