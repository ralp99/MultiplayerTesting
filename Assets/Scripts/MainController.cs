using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainController : MonoBehaviour
{

    public Renderer ObjectRenderer;
    private PhotonView photonView;
    public TumbleObject TumbleObject;

    Transform spinningTransform;


    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        spinningTransform = TumbleObject.transform;



        //spinningTransform = TumbleObject.gameObject.GetComponent<Transform>();
    }

    public void CloseApp()
    {
        Application.Quit();
    }



    public void PerformColorChange(int colorNumber)
    {
        // 1 red
        // 2 green
        // 3 blue

        Color newColor = Color.red;

        if (colorNumber == 1)
        {
            newColor = Color.green;
        }

        if (colorNumber == 2)
        {
            newColor = Color.blue;
        }

        ObjectRenderer.material.SetColor("_Color", newColor);
    }





    // should use this to change positions
    //[PunRPC]
    public void TumbleSelectedObject(Vector3 newAngles)
    {
       // spinningTransform.localEulerAngles = newAngles;

        photonView.RPC("SpinExternalInstances", RpcTarget.AllViaServer, newAngles);



    }

    [PunRPC]
    private void SpinExternalInstances(Vector3 newAngles)
    {
        if (TumbleObject.isDragging)
        {
            return;
        }

        spinningTransform.localEulerAngles = newAngles;
    }



    public void ColorChange(int colorNumber)

    {
        // incoming from buttonPress

        // affect color of local object following local button press
        PerformColorChange(colorNumber);

        photonView.RPC("ColorExternalInstances", RpcTarget.AllViaServer, colorNumber);
        //  photonView.RPC("ColorExternalInstances", RpcTarget.MasterClient, colorNumber);  // one way only!

    }

    public void ResetRotation()
    {
        TumbleSelectedObject(TumbleObject.initState);
    }



    [PunRPC]
    private void ColorExternalInstances(int colorValue)
    {
        PerformColorChange(colorValue);
    }



    /*
    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

        }

        if (stream.IsReading)
        {
        //    ColorChange()
        }

    }
    */


}
